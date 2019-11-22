using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using MicroQuiz.Services.Quizzes.Core.Extensions;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Core.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Application.QueryHandlers
{
    public class GetQuizQuestionListQueryHandler : IRequestHandler<GetQuizQuestionListQuery, QuizQuestionListDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadQuestionRepository _readQuestionRepository;

        public GetQuizQuestionListQueryHandler(IMapper mapper, IReadQuestionRepository readQuestionRepository)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _readQuestionRepository = readQuestionRepository.ThrowIfNull(nameof(readQuestionRepository));
        }

        public async Task<QuizQuestionListDto> Handle(GetQuizQuestionListQuery request, CancellationToken cancellationToken)
        {
            var list = await _readQuestionRepository.GetByQuizIdAsync(request.QuizId);

            var dtos = list
                .Select(entity => _mapper.Map<QuestionDto>(entity));

            return new QuizQuestionListDto { Questions = dtos };
        }
    }
}
