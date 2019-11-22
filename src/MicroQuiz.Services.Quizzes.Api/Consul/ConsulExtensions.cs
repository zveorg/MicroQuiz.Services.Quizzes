using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroQuiz.Services.Quizzes.Api.Consul
{
    public static class ConsulExtensions
    {
        public static IServiceCollection AddAndConfigureConsul(this IServiceCollection services, IConfiguration configuration)
        {
            var consulConfig = new ConsulConfig();
            configuration.Bind("Consul", consulConfig);
            var consulClient = CreateConsulClient(consulConfig);

            services.AddHealthChecks();

            services.AddSingleton(consulConfig)
                .AddSingleton<IHostedService, ConsulHostedService>()
                .AddSingleton<IConsulClient, ConsulClient>(p => consulClient);

            return services;
        }

        private static ConsulClient CreateConsulClient(ConsulConfig serviceConfig)
        {
            return new ConsulClient(config =>
            {
                config.Address = serviceConfig.DiscoveryAddress;
            });
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            var config = app.ApplicationServices.GetService<ConsulConfig>();
            app.UseHealthChecks(config.PingEndpoint);

            return app;
        }
    }
}
