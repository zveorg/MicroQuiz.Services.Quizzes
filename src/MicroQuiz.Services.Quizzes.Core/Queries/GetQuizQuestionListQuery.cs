using MediatR;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using System;

namespace MicroQuiz.Services.Quizzes.Core.Queries
{
    public class GetQuizQuestionListQuery : IRequest<QuizQuestionListDto>
    {
        public GetQuizQuestionListQuery(Guid id)
        {
            QuizId = id;
        }

        public Guid QuizId { get; }
    }
}
