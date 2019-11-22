using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Infrastructure.Dapper.Configuration;
using MicroQuiz.Services.Quizzes.Infrastructure.Dapper.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroQuiz.Services.Quizzes.Infrastructure.Dapper
{
    public static class Extensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(options => new ReadDbContext(configuration.GetConnectionString("MySqlConnection")));

            services.AddScoped<IReadQuizRepository, ReadQuizRepository>();
            services.AddScoped<IReadQuestionRepository, ReadQuestionRepository>();

            return services;
        }

        public static IApplicationBuilder UseDapper(this IApplicationBuilder app)
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new QuizMap());
                config.AddMap(new QuestionMap());
                config.ForDommel();
            });

            return app;
        }
    }
}
