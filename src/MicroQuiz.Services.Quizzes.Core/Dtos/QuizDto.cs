using System;

namespace MicroQuiz.Services.Quizzes.Core.Dtos
{
    public class QuizDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int QuestionCount { get; set; }
    }
}
