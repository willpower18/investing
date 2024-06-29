using Investing.Application.Interfaces.Queries;
using Investing.Domain.Entities;

namespace Investing.Application.Queries.AssetClassQueries
{
    public class AssetClassQueryResultBase : QueryResultBase, IQueryResult
    {
        private AssetClass _assetClass = null;
        private IList<AssetClass> _assetClasses = new List<AssetClass>();

        public AssetClassQueryResultBase(string message) : base(message) { }

        public AssetClassQueryResultBase(string message, IEnumerable<string> erros) : base(message, erros) { }

        public AssetClass Result => _assetClass;

        public IReadOnlyCollection<AssetClass> Results => _assetClasses.ToArray();

        internal void AddEntitiesToResult(IEnumerable<AssetClass> entities)
        {
            if(entities != null)
            {
                foreach(var entity in entities)
                {
                    _assetClasses.Add(entity);
                }
            }
        }

        internal void AddEntityToResult(AssetClass entity) => _assetClass = entity;
    }
}
