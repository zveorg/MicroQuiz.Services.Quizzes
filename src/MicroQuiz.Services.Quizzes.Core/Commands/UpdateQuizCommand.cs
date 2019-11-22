using MediatR;
using MicroQuiz.Services.Quizzes.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroQuiz.Services.Quizzes.Core.Commands
{
    public class UpdateQuizCommand : IRequest
    {
        [RequiredGuidId]
        public Guid Id { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(300)]
        public string Description { get; set; }
    }
}
