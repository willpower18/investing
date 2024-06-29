namespace Investing.Application.Commands.AssetClassCommands.DisableAssetClass
{
    public sealed class DisableAssetClassResult : CommandResultBase
    {
        public DisableAssetClassResult(string message) : base(message)
        {
        }

        public DisableAssetClassResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }
    }
}
