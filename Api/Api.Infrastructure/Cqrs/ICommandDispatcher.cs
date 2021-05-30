using System.Threading.Tasks;
using Api.Application.Handlers;

namespace Api.Infrastructure.Cqrs
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : class, ICommand;
    }
}