using Flunt.Validations;
using Investing.Shared.GlobalEntities;
using Investing.Shared.GlobalEnumerators;

namespace Investing.Domain.Entities
{
    public class AssetClass : DefaultEntity
    {
        public AssetClass(string name, string description) : base()
        {
            Name = name;
            Description = description;
            ValidateEntity();
        }

        public AssetClass(Guid id, string name, string description, EActiveStatus status) : base(id, status)
        {
            Name = name;
            Description = description;
            ValidateEntity();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        
        private void ValidateEntity()
        {
            AddNotifications(new Contract<AssetClass>()
               .IsNotNullOrEmpty(Name, "Name", "Invalid name. The name must be provided")
               .IsLowerOrEqualsThan(Name, 100, "Name", "The name must contain up to 100 characters")
               .IsNotNullOrEmpty(Description, "Description", "Invalid description. The description must be provided")
               .IsLowerOrEqualsThan(Description, 200, "Description", "The description must contain up to 200 characters")
            );
        }
    }
}
