using Flunt.Validations;
using Investing.Shared.GlobalEntities;
using Investing.Shared.GlobalEnumerators;

namespace Investing.Domain.Entities
{
    public class Asset : DefaultEntity
    {
        public Asset(Guid assetClassId, Guid sectorId, string ticker, string name, string logoUrl, double percentage) : base()
        {
            AssetClassId = assetClassId;
            SectorId = sectorId;
            Ticker = ticker;
            Name = name;
            LogoUrl = logoUrl;
            Percentage = percentage;
            ValidateEntity();
        }

        public Asset(Guid id, Guid assetClassId, Guid sectorId, string ticker, string name, string logoUrl, double percentage, EActiveStatus status) : base(id, status)
        {
            AssetClassId = assetClassId;
            SectorId = sectorId;
            Ticker = ticker;
            Name = name;
            LogoUrl = logoUrl;
            Percentage = percentage;
            ValidateEntity();
        }

        public Guid AssetClassId { get; private set; }
        public Guid SectorId { get; private set; }
        public string Ticker { get; private set; }
        public string Name { get; private set; }
        public string LogoUrl { get; private set; }
        public double Percentage { get; private set; }

        private void ValidateEntity()
        {
            AddNotifications(new Contract<Asset>()
               .AreNotEquals(AssetClassId, Guid.Empty, "AssetClassId", "Invalid Asset Class. The Asset Class Id must be provided")
               .AreNotEquals(SectorId, Guid.Empty, "SectorId", "Invalid Sector. The Sector Id must be provided")
               .IsNotNullOrEmpty(Ticker, "Ticker", "Invalid ticker. The ticker must be provided")
               .IsLowerOrEqualsThan(Ticker, 10, "Ticker", "The ticker must contain up to 10 characters")
               .IsNotNullOrEmpty(Name, "Name", "Invalid name. The name must be provided")
               .IsLowerOrEqualsThan(Name, 100, "Name", "The name must contain up to 100 characters")
               .IsNotNullOrEmpty(LogoUrl, "LogoUrl", "Invalid Logo Url. The Logo Url must be provided")
               .IsLowerOrEqualsThan(LogoUrl, 300, "LogoUrl", "The Logo Url must contain up to 300 characters")
               .IsGreaterOrEqualsThan(Percentage, 0.1, "Percentage", "The percentage must be higher than 0")
            );
        }
    }
}
