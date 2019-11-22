using System.Collections.Generic;

namespace MicroQuiz.Services.Quizzes.Core.Dtos
{
    public class QuizListDto
    {
        public IEnumerable<QuizDto> QuizList { get; set; }
    }
}
