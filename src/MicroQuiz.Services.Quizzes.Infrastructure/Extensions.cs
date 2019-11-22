using MicroQuiz.Services.Quizzes.Infrastructure.Dapper;
using MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework;
using MicroQuiz.Services.Quizzes.Infrastructure.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroQuiz.Services.Quizzes.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFramework(configuration)
                .AddDapper(configuration)
                .AddRabbitMq(configuration);

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app
                .UseEntityFramework()
                .UseDapper()
                .UseRabbit();

            return app;
        }
    }
}
