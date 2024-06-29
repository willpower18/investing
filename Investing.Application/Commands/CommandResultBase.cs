using Investing.Application.Interfaces.Commands;
using System.Text;

namespace Investing.Application.Commands
{
    public abstract class CommandResultBase : ICommandResult
    {
        private List<string> _errors = new List<string>();

        public CommandResultBase(string message)
        {
            Message = message;
        }

        public CommandResultBase(string message, IEnumerable<string> errors)
        {
            Message = message;
            _errors.AddRange(errors);
        }

        public bool Succed => _errors.Any() ? false : true;

        public string Message { get; }

        public IReadOnlyCollection<string> Errors => _errors.ToArray();       

        public string GetCompiledErrorList()
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
