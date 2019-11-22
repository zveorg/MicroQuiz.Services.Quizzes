using MediatR;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.CommandHandlers
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand>
    {
        private readonly IWriteQuizRepository _writeQuizRepository;

        public DeleteQuizCommandHandler(IWriteQuizRepository writeQuizRepository)
        {
            _writeQuizRepository = writeQuizRepository.ThrowIfNull(nameof(writeQuizRepository));
        }

        public async Task<Unit> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            _writeQuizRepository.Delete(request.Id);

            await _writeQuizRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}