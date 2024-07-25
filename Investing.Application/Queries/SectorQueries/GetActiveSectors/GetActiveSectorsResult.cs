namespace Investing.Application.Queries.SectorQueries.GetActiveSectors
{
    public sealed class GetActiveSectorsResult : SectorQueryResultBase
    {
        public GetActiveSectorsResult(string message) : base(message)
        {
        }

        public GetActiveSectorsResult(string message, IEnumerable<string> erros) : base(message, erros)
        {
        }
    }
}
