using System;
using Api.Application.Messages;
using Api.Infrastructure.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Initialize
{
    public static class MessagesExtensions
    {
        public static IServiceCollection AddEventBroker(this IServiceCollection services)
        {
            services.AddSingleton<IEventBroker, EventBroker>();
            return services;
        }

        public static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            return services;
        }
    }
}