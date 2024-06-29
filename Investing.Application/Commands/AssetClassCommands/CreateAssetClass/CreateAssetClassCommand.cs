using Flunt.Validations;
using Investing.Application.Interfaces.Commands;
using Investing.Domain.Entities;

namespace Investing.Application.Commands.AssetClassCommands.CreateAssetClass
{
    public sealed class CreateAssetClassCommand : CommandBase, ICommand<CreateAssetClassResult>
    {
        public CreateAssetClassCommand(AssetClass assetClass)
        {
            AssetClass = assetClass;
            ValidateCommand();
        }

        public AssetClass AssetClass { get; private set; }

        private void ValidateCommand()
        {
            AddNotifications(new Contract<CreateAssetClassCommand>()
                .AreNotEquals(AssetClass, null, "AssetClass", "The Asset Class must be provided")    
            );
        }
    }
}
