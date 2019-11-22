using AutoMapper;
using MediatR;
using MicroQuiz.Services.Quizzes.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MicroQuiz.Services.Quizzes.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddAutoMapper()
                .AddMediatR(typeof(Extensions).GetTypeInfo().Assembly);

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new QuizMappingProfile());
                mc.AddProfile(new QuestionMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
