using MediatR;
using MicroQuiz.Services.Quizzes.Core.Events;

namespace MicroQuiz.Services.Quizzes.Core.Messaging
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeEvent<TEvent>() where TEvent : IEvent, IRequest;
    }
}
