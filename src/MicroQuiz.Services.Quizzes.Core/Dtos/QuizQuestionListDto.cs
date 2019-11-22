using System.Collections.Generic;

namespace MicroQuiz.Services.Quizzes.Core.Dtos
{
    public class QuizQuestionListDto
    {
        public IEnumerable<QuestionDto> Questions { get; set; }
    }
}
