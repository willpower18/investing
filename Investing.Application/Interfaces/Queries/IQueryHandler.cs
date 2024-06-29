using Investing.Shared.GlobalEntities;
using MediatR;

namespace Investing.Application.Interfaces.Queries
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>, IRequest<TResult> where TResult : IQueryResult
    {
    }
}
