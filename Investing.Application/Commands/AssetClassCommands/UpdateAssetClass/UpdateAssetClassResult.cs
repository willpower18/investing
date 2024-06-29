namespace Investing.Application.Commands.AssetClassCommands.UpdateAssetClass
{
    public sealed class UpdateAssetClassResult : CommandResultBase
    {
        public UpdateAssetClassResult(string message) : base(message)
        {
        }

        public UpdateAssetClassResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }
    }
}
