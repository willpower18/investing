using Flunt.Validations;
using Investing.Shared.GlobalEntities;
using Investing.Shared.GlobalEnumerators;

namespace Investing.Domain.Entities
{
    public class Sector : DefaultEntity
    {
        public Sector(Guid assetClassId, string name, string description) : base()
        {
            AssetClassId = assetClassId;
            Name = name;
            Description = description;
            ValidateEntity();
        }

        public Sector(Guid id, Guid assetClassId, string name, string description, EActiveStatus status) : base(id, status)
        {
            AssetClassId = assetClassId;
            Name = name;
            Description = description;
            ValidateEntity();
        }

        public Guid AssetClassId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string AssetClassName { get; private set; }

        public void ProvideAssetClassName(string assetClassName)
        {
            AssetClassName = assetClassName;
        }

        private void ValidateEntity()
        {
            AddNotifications(new Contract<Sector>()
               .AreNotEquals(AssetClassId, Guid.Empty, "AssetClassId", "Invalid Asset Class. The Asset Class Id must be provided")
               .IsNotNullOrEmpty(Name, "Name", "Invalid name. The name must be provided")
               .IsLowerOrEqualsThan(Name, 100, "Name", "The name must contain up to 100 characters")
               .IsNotNullOrEmpty(Description, "Description", "Invalid description. The description must be provided")
               .IsLowerOrEqualsThan(Description, 200, "Description", "The description must contain up to 200 characters")
            );
        }
    }
}
