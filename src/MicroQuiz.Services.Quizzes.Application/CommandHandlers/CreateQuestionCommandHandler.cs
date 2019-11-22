using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.CommandHandlers
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IWriteQuestionRepository _writeQuestionRepository;

        public CreateQuestionCommandHandler(IMapper mapper, IWriteQuestionRepository writeQuestionRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _writeQuestionRepository = writeQuestionRepository.ThrowIfNull(nameof(writeQuestionRepository));
        }

        public async Task<Unit> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Question>(request);
            entity.CreatedAt = DateTime.UtcNow;

            _writeQuestionRepository.Create(entity);

            await _writeQuestionRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
