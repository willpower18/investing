namespace Investing.Application.Queries.AssetClassQueries.GetAssetClassById
{
    public sealed class GetAssetClassByIdResult : AssetClassQueryResultBase
    {
        public GetAssetClassByIdResult(string message) : base(message)
        {
        }

        public GetAssetClassByIdResult(string message, IEnumerable<string> erros) : base(message, erros)
        {
        }
    }
}
