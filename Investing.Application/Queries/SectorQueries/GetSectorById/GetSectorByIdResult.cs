namespace Investing.Application.Queries.SectorQueries.GetSectorById
{
    public sealed class GetSectorByIdResult : SectorQueryResultBase
    {
        public GetSectorByIdResult(string message) : base(message)
        {
        }

        public GetSectorByIdResult(string message, IEnumerable<string> erros) : base(message, erros)
        {
        }
    }
}
