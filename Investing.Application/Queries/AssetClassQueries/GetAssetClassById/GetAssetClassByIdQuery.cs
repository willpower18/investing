using Flunt.Validations;
using Investing.Application.Interfaces.Queries;

namespace Investing.Application.Queries.AssetClassQueries.GetAssetClassById
{
    public sealed class GetAssetClassByIdQuery : QueryBase, IQuery<GetAssetClassByIdResult>
    {
        public GetAssetClassByIdQuery(Guid assetClassId)
        {
            AssetClassId = assetClassId;
            ValidateQuery();
        }

        public Guid AssetClassId { get; private set; }

        private void ValidateQuery()
        {
            AddNotifications(new Contract<GetAssetClassByIdQuery>()
                  .AreNotEquals(AssetClassId, Guid.Empty, "AssetClassId", "Invalid Asset Class Id")
            );
        }
    }
}
