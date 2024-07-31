using Flunt.Validations;
using Investing.Application.Interfaces.Commands;
using Investing.Domain.Entities;

namespace Investing.Application.Commands.SectorCommands.UpdateSector
{
    public sealed class UpdateSectorCommand : CommandBase, ICommand<UpdateSectorResult>
    {
        public UpdateSectorCommand(Sector sector)
        {
            Sector = sector;
            ValidateCommand();
        }

        public Sector Sector { get; private set; }

        private void ValidateCommand()
        {
            AddNotifications(new Contract<UpdateSectorCommand>()
               .AreNotEquals(Sector, null, "Sector", "Invalid Sector. The Sector must be provided")
            );
        }
    }
}
