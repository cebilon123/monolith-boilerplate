using System.Threading.Tasks;

namespace Api.Application.Messages
{
    public interface IEventHandler<in TEvent> where TEvent: class, IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}