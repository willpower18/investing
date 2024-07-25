using Investing.Application.Interfaces.Queries;
using Investing.Domain.Entities;
using Investing.Shared.DataTransferObjects;

namespace Investing.Application.Queries.SectorQueries
{
    public class SectorQueryResultBase : QueryResultBase, IQueryResult
    {
        private Sector _sector = null;
        private IList<SectorWithAssetClassDTO> _sectors = new List<SectorWithAssetClassDTO>();

        public SectorQueryResultBase(string message) : base(message) { }

        public SectorQueryResultBase(string message, IEnumerable<string> erros) : base(message, erros) { }

        public Sector Result => _sector;

        public IReadOnlyCollection<SectorWithAssetClassDTO> Results => _sectors.ToArray();

        internal void AddEntitiesToResult(IEnumerable<SectorWithAssetClassDTO> entities)
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    _sectors.Add(entity);
                }
            }
        }

        internal void AddEntityToResult(Sector entity) => _sector = entity;
    }
}
