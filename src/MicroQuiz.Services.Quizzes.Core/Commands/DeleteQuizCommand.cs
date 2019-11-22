using MediatR;
using System;

namespace MicroQuiz.Services.Quizzes.Core.Commands
{
    public class DeleteQuizCommand : IRequest
    {
        public DeleteQuizCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
