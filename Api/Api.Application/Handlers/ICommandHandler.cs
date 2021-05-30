using System.Threading.Tasks;

namespace Api.Application.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}