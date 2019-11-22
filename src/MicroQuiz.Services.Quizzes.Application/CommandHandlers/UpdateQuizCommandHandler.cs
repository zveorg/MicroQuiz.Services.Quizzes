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
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand>
    {
        private readonly IMapper _mapper;
        private readonly IWriteQuizRepository _writeQuizRepository;

        public UpdateQuizCommandHandler(IMapper mapper, IWriteQuizRepository writeQuizRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _writeQuizRepository = writeQuizRepository.ThrowIfNull(nameof(writeQuizRepository));
        }

        public async Task<Unit> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            if (request?.Id == null) return Unit.Value; //TODO: Add notification

            var entity = _mapper.Map<Quiz>(request);
            _writeQuizRepository.Update(entity);

            await _writeQuizRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
