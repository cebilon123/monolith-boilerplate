using System.Threading.Tasks;
using Api.Application.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Cqrs
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceScopeFactory _serviceFactory;

        public CommandDispatcher(IServiceScopeFactory serviceFactory) => _serviceFactory = serviceFactory;

        public async Task SendAsync<T>(T command) where T : class, ICommand
        {
            using (IServiceScope scope = this._serviceFactory.CreateScope())
                await scope.ServiceProvider.GetRequiredService<ICommandHandler<T>>().HandleAsync(command);
        }
    }
}