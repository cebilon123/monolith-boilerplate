using System.Threading.Tasks;
using Api.Application.Handlers;

namespace Api.Infrastructure.Cqrs
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);

        Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>;
    }
}