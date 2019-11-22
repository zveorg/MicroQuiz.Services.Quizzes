using MediatR;
using System;

namespace MicroQuiz.Services.Quizzes.Core.Commands
{
    public class DeleteQuestionCommand : IRequest
    {
        public DeleteQuestionCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
