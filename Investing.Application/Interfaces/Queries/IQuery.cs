using Investing.Shared.GlobalEntities;
using MediatR;

namespace Investing.Application.Interfaces.Queries
{
    public interface IQuery<IQueryResult> : IRequest<IQueryResult>
    {
    }
}
