namespace Investing.Application.Interfaces.Gateways
{
    public interface IApplicationServiceDefaultResult
    {
        public bool Succed { get; }
        public string Message { get; }
        public string CompiledErrorMessages { get; }
        public IReadOnlyCollection<string> Errors { get; }
    }
}
