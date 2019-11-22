using MicroQuiz.Services.Quizzes.Core.Interfaces.Repositories;
using MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroQuiz.Services.Quizzes.Infrastructure.EntityFramework
{
    public static class Extensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WriteDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("MySqlConnection")));

            services.AddScoped<IWriteQuizRepository, WriteQuizRepository>();
            services.AddScoped<IWriteQuestionRepository, WriteQuestionRepository>();

            return services;
        }

        public static IApplicationBuilder UseEntityFramework(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<WriteDbContext>().Database.Migrate();
            }

            return app;
        }
    }
}
