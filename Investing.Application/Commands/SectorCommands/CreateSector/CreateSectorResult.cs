namespace Investing.Application.Commands.SectorCommands.CreateSector
{
    public sealed class CreateSectorResult : CommandResultBase
    {
        public CreateSectorResult(string message) : base(message)
        {
        }

        public CreateSectorResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }
    }
}
