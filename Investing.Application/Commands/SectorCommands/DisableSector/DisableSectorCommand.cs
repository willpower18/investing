using Flunt.Validations;
using Investing.Application.Interfaces.Commands;

namespace Investing.Application.Commands.SectorCommands.DisableSector
{
    public sealed class DisableSectorCommand : CommandBase, ICommand<DisableSectorResult>
    {
        public DisableSectorCommand(Guid sectorId)
        {
            SectorId = sectorId;
            ValidateCommand();
        }

        public Guid SectorId { get; private set; }

        private void ValidateCommand()
        {
            AddNotifications(new Contract<DisableSectorCommand>()
                .AreNotEquals(SectorId, Guid.Empty, "SectorId", "The Sector ID must be provided")
            );
        }
    }
}
