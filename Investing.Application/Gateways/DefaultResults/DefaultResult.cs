using Investing.Application.Interfaces.Gateways;
using System.Text;

namespace Investing.Application.Gateways.CommandResults
{
    public abstract class DefaultResult : IApplicationServiceCommandResult
    {
        private List<string> _errors = new List<string>();

        public DefaultResult(string message)
        {
            Message = message;
            CompiledErrorMessages = GetCompiledErrorList();
        }

        public DefaultResult(string message, IEnumerable<string> errors)
        {
            Message = message;
            _errors.AddRange(errors);
            CompiledErrorMessages = GetCompiledErrorList();
        }

        public bool Succed => _errors.Any() ? false : true;
        public string Message { get; }
        public string CompiledErrorMessages { get; }

        public IReadOnlyCollection<string> Errors => _errors.ToArray();

        private string GetCompiledErrorList()
        {
            if (Errors != null)
            {
                if (Errors.Any())
                {
                    int counter = 1;
                    StringBuilder errors = new StringBuilder();
                    foreach (string error in Errors)
                    {
                        if (counter != Errors.Count)
                            errors.Append(string.Concat(error, ", "));
                        else
                            errors.Append(error);

                        counter++;
                    }

                    return errors.ToString();
                }
            }

            return string.Empty;
        }
    }
}
