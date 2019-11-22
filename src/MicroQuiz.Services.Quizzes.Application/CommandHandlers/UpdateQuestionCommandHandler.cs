using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.CommandHandlers
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IWriteQuestionRepository _writeQuestionRepository;

        public UpdateQuestionCommandHandler(IMapper mapper, IWriteQuestionRepository writeQuestionRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _writeQuestionRepository = writeQuestionRepository.ThrowIfNull(nameof(writeQuestionRepository));
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            if (request?.Id == null) return Unit.Value; //TODO: Add notification

            var entity = _mapper.Map<Question>(request);
            _writeQuestionRepository.Update(entity);

            await _writeQuestionRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
