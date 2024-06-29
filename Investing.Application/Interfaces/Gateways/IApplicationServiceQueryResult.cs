using Investing.Shared.GlobalEntities;

namespace Investing.Application.Interfaces.Gateways
{
    public interface IApplicationServiceQueryResult<T> : IApplicationServiceDefaultResult where T : DefaultEntity
    {
        T Result { get; set; }
        IReadOnlyCollection<T> Results { get; }

        void SetResult(T result);
        void SetResults(IEnumerable<T> results);
    }
}
