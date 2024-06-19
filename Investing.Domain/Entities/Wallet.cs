using Flunt.Validations;
using Investing.Shared.GlobalEntities;
using Investing.Shared.GlobalEnumerators;

namespace Investing.Domain.Entities
{
    public class Wallet : DefaultEntity
    {
        public Wallet(Guid assetClassId, double percentage) : base()
        {
            AssetClassId = assetClassId;
            Percentage = percentage;
            ValidateEntity();
        }

        public Wallet(Guid id, Guid assetClassId, double percentage, EActiveStatus status) : base(id, status)
        {
            AssetClassId = assetClassId;
            Percentage = percentage;
            ValidateEntity();
        }

        public Guid AssetClassId { get; private set; }
        public double Percentage { get; private set; }

        private void ValidateEntity()
        {
            AddNotifications(new Contract<Wallet>()
               .AreNotEquals(AssetClassId, Guid.Empty, "AssetClassId", "Invalid Asset Class. The Asset Class Id must be provided")
               .IsGreaterOrEqualsThan(Percentage, 0.1, "Percentage", "The percentage must be higher than 0")
            );
        }
    }
}
