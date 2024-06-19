using Flunt.Validations;
using Investing.Shared.GlobalEntities;
using Investing.Shared.GlobalEnumerators;

namespace Investing.Domain.Entities
{
    public class SectorConfiguration : DefaultEntity
    {
        public SectorConfiguration(Guid assetClassId, Guid sectorId, double percentage)
        {
            AssetClassId = assetClassId;
            SectorId = sectorId;
            Percentage = percentage;
            ValidateEntity();
        }

        public SectorConfiguration(Guid id, Guid assetClassId, Guid sectorId, double percentage, EActiveStatus status) : base(id, status)
        {
            AssetClassId = assetClassId;
            SectorId = sectorId;
            Percentage = percentage;
            ValidateEntity();
        }

        public Guid AssetClassId { get; private set; }
        public Guid SectorId { get; private set; }
        public double Percentage { get; private set; }

        private void ValidateEntity()
        {
            AddNotifications(new Contract<SectorConfiguration>()
               .AreNotEquals(AssetClassId, Guid.Empty, "AssetClassId", "Invalid Asset Class. The Asset Class Id must be provided")
               .AreNotEquals(SectorId, Guid.Empty, "SectorId", "Invalid Sector. The Sector Id must be provided")
               .IsGreaterOrEqualsThan(Percentage, 0.1, "Percentage", "The percentage must be higher than 0")
            );
        }
    }
}
