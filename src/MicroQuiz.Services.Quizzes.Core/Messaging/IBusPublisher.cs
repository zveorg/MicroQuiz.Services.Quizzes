using MicroQuiz.Services.Quizzes.Core.Events;
using System.Threading.Tasks;

namespace MicroQuiz.Services.Quizzes.Core.Messaging
{
    public interface IBusPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
