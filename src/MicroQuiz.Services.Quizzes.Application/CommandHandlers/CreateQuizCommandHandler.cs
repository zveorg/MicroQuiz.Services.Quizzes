using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Events.Quiz;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Core.Messaging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.CommandHandlers
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand>
    {
        private readonly IMapper _mapper;
        private readonly IWriteQuizRepository _writeQuizRepository;
        private readonly IReadQuizRepository _readQuizRepository;

        public CreateQuizCommandHandler(
            IMapper mapper, 
            IReadQuizRepository readQuizRepository,
            IWriteQuizRepository writeQuizRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _readQuizRepository = readQuizRepository.ThrowIfNull(nameof(readQuizRepository));
            _writeQuizRepository = writeQuizRepository.ThrowIfNull(nameof(writeQuizRepository));
        }

        public async Task<Unit> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var exists = await _readQuizRepository.GetByIdOrNameAsync(request.Id, request.Name);
            if(exists.Any())
            {
                //TODO: Add log and/or notification.
                return Unit.Value;
            }

            var entity = _mapper.Map<Quiz>(request);
            entity.CreatedAt = DateTime.UtcNow;

            _writeQuizRepository.Create(entity);

            await _writeQuizRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
