using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;

namespace MicroQuiz.Services.Quizzes.Core.Queries
{
    public class GetQuizListQuery : IRequest<QuizListDto>
    {
        public bool EnabledOnly { get; set; }
    }
}
