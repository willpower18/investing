using Flunt.Validations;
using Investing.Application.Interfaces.Queries;

namespace Investing.Application.Queries.SectorQueries.GetSectorById
{
    public sealed class GetSectorByIdQuery : QueryBase, IQuery<GetSectorByIdResult>
    {
        public GetSectorByIdQuery(Guid sectorId)
        {
            SectorId = sectorId;
            ValidateQuery();
        }

        public Guid SectorId { get; private set; }

        private void ValidateQuery()
        {
            AddNotifications(new Contract<GetSectorByIdQuery>()
                  .AreNotEquals(SectorId, Guid.Empty, "SectorId", "Invalid Sector Id")
            );
        }
    }
}
