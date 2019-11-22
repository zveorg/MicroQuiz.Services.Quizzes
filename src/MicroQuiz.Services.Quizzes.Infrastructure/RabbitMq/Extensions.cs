using MicroQuiz.Services.Quizzes.Core.Events.Quiz;
using MicroQuiz.Services.Quizzes.Core.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Instantiation;

namespace MicroQuiz.Services.Quizzes.Infrastructure.RabbitMq
{
    public static class Extensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RawRabbitConfiguration();
            configuration.GetSection("RabbitMq").Bind(options);

            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);

            services.AddScoped<IBusPublisher, BusPublisher>();

            return services;
        }

        public static IApplicationBuilder UseRabbit(this IApplicationBuilder app)
        {
            app.UseRabbitMq()
                .SubscribeEvent<CreateQuizEvent>();

            return app;
        }

        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
            => new BusSubscriber(app);
    }
}
