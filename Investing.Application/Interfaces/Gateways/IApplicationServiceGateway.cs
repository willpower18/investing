using Investing.Shared.GlobalEntities;

namespace Investing.Application.Interfaces.Gateways
{
    public interface IApplicationServiceGateway<T> where T : DefaultEntity
    {
        Task<IApplicationServiceQueryResult<T>> GetById(Guid id);
        Task<IApplicationServiceQueryResult<T>> GetActiveRecords();
        Task<IApplicationServiceCommandResult> Create(T entity);
        Task<IApplicationServiceCommandResult> Update(T entity);
        Task<IApplicationServiceCommandResult> Inactivate(Guid id);        
    }
}
