using MediatR;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.CommandHandlers
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IWriteQuestionRepository _writeQuestionRepository;

        public DeleteQuestionCommandHandler(IWriteQuestionRepository writeQuestionRepository)
        {
            _writeQuestionRepository = writeQuestionRepository.ThrowIfNull(nameof(writeQuestionRepository));
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            _writeQuestionRepository.Delete(request.Id);

            await _writeQuestionRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
