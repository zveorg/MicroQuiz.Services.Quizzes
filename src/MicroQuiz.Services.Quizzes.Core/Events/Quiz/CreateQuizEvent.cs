using MediatR;
using System;

namespace MicroQuiz.Services.Quizzes.Core.Events.Quiz
{
    public class CreateQuizEvent : IEvent, IRequest
    {
        public Guid OperationId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
