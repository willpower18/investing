using Flunt.Validations;
using Investing.Application.Interfaces.Commands;

namespace Investing.Application.Commands.AssetClassCommands.DisableAssetClass
{
    public sealed class DisableAssetClassCommand : CommandBase, ICommand<DisableAssetClassResult>
    {
        public DisableAssetClassCommand(Guid assetClassId)
        {
            AssetClassId = assetClassId;
            ValidateCommand();
        }

        public Guid AssetClassId { get; private set; }

        private void ValidateCommand()        {
            AddNotifications(new Contract<DisableAssetClassCommand>()
                .AreNotEquals(AssetClassId, Guid.Empty, "AssetClassId", "The Asset Class ID must be provided")
            );
        }
    }
}
