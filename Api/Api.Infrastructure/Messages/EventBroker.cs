using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Messages
{
    public class EventBroker : IEventBroker
    {
        private readonly IServiceScopeFactory _serviceFactory;

        public EventBroker(IServiceScopeFactory serviceFactory) => _serviceFactory = serviceFactory;
        
        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            using IServiceScope scope = _serviceFactory.CreateScope();
            var eventHandlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();
            
            foreach (var eventHandler in eventHandlers)
            {
                await eventHandler.HandleAsync(@event);
            }
        }
    }
}