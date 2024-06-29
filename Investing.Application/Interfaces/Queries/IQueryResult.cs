namespace Investing.Application.Interfaces.Queries
{
    public interface IQueryResult
    {
        public bool Succed { get; }
        public string Message { get; }
        public IReadOnlyCollection<string> Errors { get; }
    }
}
