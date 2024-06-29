using Investing.Application.Gateways.CommandResults;

namespace Investing.Application.Gateways.DefaultResults
{
    public class DefaultCommandResult : DefaultResult
    {
        public DefaultCommandResult(string message) : base(message)
        {
        }

        public DefaultCommandResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }
    }
}
