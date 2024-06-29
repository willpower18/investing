namespace Investing.Application.Queries.AssetClassQueries.GetActiveAssetClasses
{
    public sealed class GetActiveAssetClassesResult : AssetClassQueryResultBase
    {
        public GetActiveAssetClassesResult(string message) : base(message)
        {
        }

        public GetActiveAssetClassesResult(string message, IEnumerable<string> erros) : base(message, erros)
        {
        }
    }
}
