using System;

namespace MicroQuiz.Services.Quizzes.Core.Entities
{
    public class Question : IEquatable<Question>
    {
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Quiz Quiz { get; set; }

        public bool Equals(Question other) => Id == other.Id;
    }
}
