using Consul;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Api.Consul
{
    public class ConsulHostedService : IHostedService
    {
        private readonly IConsulClient _client;
        private readonly ConsulConfig _config;
        private string _registrationId;

        public ConsulHostedService(IConsulClient client, ConsulConfig config)
        {
            _client = client;
            _config = config;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _registrationId = $"{_config.ServiceName}-{_config.ServiceId}";

            var registration = new AgentServiceRegistration
            {
                ID = _registrationId,
                Name = _config.ServiceName,
                Address = _config.ServiceAddress.Host,
                Port = _config.ServiceAddress.Port
            };

            var check = new AgentServiceCheck
            {
                Interval = TimeSpan.FromSeconds(_config.PingIntervalSec),
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(_config.RemoveAfterIntervalSec),
                HTTP = _config.ServiceAddress + _config.PingEndpoint.Trim('/'),
            };
            registration.Checks = new[] { check };

            await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
            await _client.Agent.ServiceRegister(registration, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.Agent.ServiceDeregister(_registrationId, cancellationToken);
        }
    }
}
