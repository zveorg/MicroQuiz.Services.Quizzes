using AutoMapper;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using MicroQuiz.Services.Quizzes.Core.Entities;
using MicroQuiz.Services.Quizzes.Core.Events.Quiz;

namespace MicroQuiz.Services.Quizzes.Application.Profiles
{
    internal class QuizMappingProfile : Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<CreateQuizCommand, Quiz>();
            CreateMap<UpdateQuizCommand, Quiz>();

            CreateMap<CreateQuizEvent, Quiz>();

            CreateMap<Quiz, QuizDto>();
        }
    }
}
