using System.Threading.Tasks;
using Api.Application.Messages;

namespace Api.Infrastructure.Messages
{
    public interface IEventBroker
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}