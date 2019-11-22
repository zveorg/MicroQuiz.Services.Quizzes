using System;
using System.Collections.Generic;
using System.Text;

namespace MicroQuiz.Services.Quizzes.Core.Events.Quiz
{
    public class CreateQuizRejectedEvent : IRejectedEvent
    {
        public Guid OperationId { get; set; }
        public Guid Id { get; set; }
        public string Reason { get; set; }
    }
}
