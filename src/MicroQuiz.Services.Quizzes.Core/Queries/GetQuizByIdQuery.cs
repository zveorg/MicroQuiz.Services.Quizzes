using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using System;

namespace MicroQuiz.Services.Quizzes.Core.Queries
{
    public class GetQuizByIdQuery : IRequest<QuizDto>
    {
        public Guid Id { get; set; }
    }
}
