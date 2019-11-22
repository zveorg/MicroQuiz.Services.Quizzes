using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using System;

namespace MicroQuiz.Services.Quizzes.Core.Queries
{
    public class GetQuestionByIdQuery : IRequest<QuestionDto>
    {
        public Guid Id { get; set; }
    }
}
