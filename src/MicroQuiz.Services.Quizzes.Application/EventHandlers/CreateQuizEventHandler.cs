using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Events.Quiz;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.EventHandlers
{
    public class CreateQuizEventHandler : IRequestHandler<CreateQuizEvent>
    {
        private readonly IWriteQuizRepository _writeQuizRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly IReadQuizRepository _readQuizRepository;
        private readonly IMapper _mapper;

        public CreateQuizEventHandler(
            IMapper mapper,
            IReadQuizRepository readQuizRepository,
            IWriteQuizRepository writeQuizRepository,
            IBusPublisher busPublisher)
        {
            _readQuizRepository = readQuizRepository.ThrowIfNull(nameof(readQuizRepository));
            _writeQuizRepository = writeQuizRepository.ThrowIfNull(nameof(writeQuizRepository));
            _busPublisher = busPublisher.ThrowIfNull(nameof(busPublisher));
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateQuizEvent request, CancellationToken cancellationToken)
        {
            var exists = await _readQuizRepository.GetByIdOrNameAsync(request.Id, request.Name);
            if (exists.Any())
            {
                var createQuizRejected = new CreateQuizRejectedEvent
                {
                    Id = request.Id,
                    OperationId = request.OperationId,
                    Reason = "There's already a quiz with such Id or/and Name."
                };
                await _busPublisher.PublishAsync(createQuizRejected);

                return Unit.Value;
            }

            var entity = _mapper.Map<Quiz>(request);
            entity.CreatedAt = DateTime.UtcNow;

            _writeQuizRepository.Create(entity);

            await _writeQuizRepository.SaveChangesAsync();

                var quizCreated = new QuizCreatedEvent
                {
                    Id = request.Id,
                    OperationId = request.OperationId
                };
                await _busPublisher.PublishAsync(quizCreated);

            return Unit.Value;
        }
    }
}
