using System.Text;

namespace Investing.Application.Queries
{
    public abstract class QueryResultBase
    {
        private List<string> _errors = new List<string>();

        public QueryResultBase(string message)
        {
            Message = message;
        }

        public QueryResultBase(string message, IEnumerable<string> erros)
        {
            Message = message;
            _errors.AddRange(erros);
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
                    int contador = 1;
                    StringBuilder errors = new StringBuilder();
                    foreach (string error in Errors)
                    {
                        if (contador != Errors.Count)
                            errors.Append(string.Concat(error, ", "));
                        else
                            errors.Append(error);

                        contador++;
                    }

                    return errors.ToString();
                }
            }

            return string.Empty;
        }
    }
}
