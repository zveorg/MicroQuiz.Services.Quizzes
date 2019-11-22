using MicroQuiz.Services.Quizzes.Core.Dtos;

namespace MicroQuiz.Services.Quizzes.Core.Interfaces.Services
{
    public interface IQuizService
    {
        QuizListDto GetQuizList(bool enabledOnly);
    }
}
