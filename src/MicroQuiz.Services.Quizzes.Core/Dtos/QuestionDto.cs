using System;

namespace MicroQuiz.Services.Quizzes.Core.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
    }
}
