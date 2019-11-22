using System;
using System.Collections.Generic;

namespace MicroQuiz.Services.Quizzes.Core.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
