using AutoMapper;
using MicroQuiz.Services.Quizzes.Core.Commands;
using MicroQuiz.Services.Quizzes.Core.Dtos;
using MicroQuiz.Services.Quizzes.Core.Entities;

namespace MicroQuiz.Services.Quizzes.Application.Profiles
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<CreateQuestionCommand, Question>();
            CreateMap<UpdateQuestionCommand, Question>();

            CreateMap<Question, QuestionDto>();
        }
    }
}
