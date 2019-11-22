using MicroQuiz.Services.Quizzes.Core.Events;
using MicroQuiz.Services.Quizzes.Core.Messaging;
using RawRabbit;
using RawRabbit.Configuration.Exchange;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Infrastructure.RabbitMq
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;

        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            await _busClient.PublishAsync(@event, ctx => ctx
                .UsePublishConfiguration(cfg => cfg
                    .OnDeclaredExchange(e => e
                        .WithName("microquiz")
                        .WithType(ExchangeType.Topic))
                    .WithRoutingKey(typeof(TEvent).Name)));
        }
    }
}
