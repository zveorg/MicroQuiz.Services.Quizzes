using MediatR;
using MicroQuiz.Services.Quizzes.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroQuiz.Services.Quizzes.Core.Commands
{
    public class UpdateQuestionCommand : IRequest
    {
        [RequiredGuidId]
        public Guid Id { get; set; }
        [Required, MaxLength(300)]
        public string Text { get; set; }
        [Required, MaxLength(300)]
        public string Answer { get; set; }
    }
}
