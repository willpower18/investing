using Flunt.Validations;
using Investing.Application.Interfaces.Commands;
using Investing.Domain.Entities;

namespace Investing.Application.Commands.SectorCommands.CreateSector
{
    public sealed class CreateSectorCommand : CommandBase, ICommand<CreateSectorResult>
    {
        public CreateSectorCommand(Sector sector)
        {
            Sector = sector;
            ValidateCommand();
        }

        public Sector Sector { get; private set; }

        private void ValidateCommand()
        {
            AddNotifications(new Contract<CreateSectorCommand>()
               .AreNotEquals(Sector, null, "Sector", "Invalid Sector. The Sector must be provided")
            );
        }
    }
}
