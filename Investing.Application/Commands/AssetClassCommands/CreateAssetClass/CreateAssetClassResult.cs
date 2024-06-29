namespace Investing.Application.Commands.AssetClassCommands.CreateAssetClass
{
    public sealed class CreateAssetClassResult : CommandResultBase
    {
        public CreateAssetClassResult(string message) : base(message)
        {
        }

        public CreateAssetClassResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }
    }
}
