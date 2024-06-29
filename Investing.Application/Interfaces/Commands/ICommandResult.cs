namespace Investing.Application.Interfaces.Commands
{
    public interface ICommandResult
    {
        public bool Succed { get; }
        public string Message { get; }

        public IReadOnlyCollection<string> Errors { get; }
    }
}
