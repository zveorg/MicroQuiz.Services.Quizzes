using System;
using System.Collections.Generic;
using System.Text;

namespace MicroQuiz.Services.Quizzes.Core.Events.Quiz
{
    public class QuizCreatedEvent : IEvent
    {
        public Guid OperationId { get; set; }
        public Guid Id { get; set; }
    }
}
