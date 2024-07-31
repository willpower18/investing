namespace Investing.Application.Commands.SectorCommands.DisableSector
{
    public sealed class DisableSectorResult : CommandResultBase
    {
        public DisableSectorResult(string message) : base(message)
        {
        }

        public DisableSectorResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }
    }
}
