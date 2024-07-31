namespace Investing.Application.Commands.SectorCommands.UpdateSector
{
    public sealed class UpdateSectorResult : CommandResultBase
    {
        public UpdateSectorResult(string message) : base(message)
        {
        }

        public UpdateSectorResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }
    }
}
