using MediatR;
using MicroQuiz.Services.Quizzes.Core.Events;
using MicroQuiz.Services.Quizzes.Core.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration.Exchange;
using System;

namespace MicroQuiz.Services.Quizzes.Infrastructure.RabbitMq
{
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IBusClient _busClient;
        private readonly IServiceProvider _serviceProvider;

        public BusSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _busClient = _serviceProvider.GetService<IBusClient>();
        }

        public IBusSubscriber SubscribeEvent<TEvent>() where TEvent : IEvent, IRequest
        {
            _busClient.SubscribeAsync<TEvent>(async (@event) =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var handler = scope.ServiceProvider.GetService<IMediator>();
                    await handler.Send(@event);
                }

            }, ctx => ctx.UseSubscribeConfiguration(cfg => cfg
                .Consume(c => c
                  .WithRoutingKey(typeof(TEvent).Name))
                .OnDeclaredExchange(e => e
                  .WithName("microquiz")
                  .WithType(ExchangeType.Topic))
            ));
            return this;
        }
    }
}
