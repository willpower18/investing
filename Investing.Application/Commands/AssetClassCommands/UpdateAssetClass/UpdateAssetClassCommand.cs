using Flunt.Validations;
using Investing.Application.Interfaces.Commands;
using Investing.Domain.Entities;

namespace Investing.Application.Commands.AssetClassCommands.UpdateAssetClass
{
    public sealed class UpdateAssetClassCommand : CommandBase, ICommand<UpdateAssetClassResult>
    {
        public UpdateAssetClassCommand(AssetClass assetClass)
        {
            AssetClass = assetClass;
            ValidateCommand();
        }

        public AssetClass AssetClass { get; private set; }

        private void ValidateCommand()
        {
            AddNotifications(new Contract<UpdateAssetClassCommand>()
                .AreNotEquals(AssetClass, null, "AssetClass", "The Asset Class must be provided")
            );
        }
    }
}
