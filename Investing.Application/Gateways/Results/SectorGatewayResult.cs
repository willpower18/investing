using Investing.Application.Gateways.CommandResults;
using Investing.Application.Interfaces.Gateways;
using Investing.Domain.Entities;

namespace Investing.Application.Gateways.Results
{
    public class SectorGatewayResult : DefaultResult, IApplicationServiceQueryResult<Sector>
    {
        private IList<Sector> _results = new List<Sector>();

        public SectorGatewayResult(string message) : base(message)
        {
        }

        public SectorGatewayResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }

        public Sector Result { get; set; }

        public IReadOnlyCollection<Sector> Results => _results.ToArray();

        public void SetResult(Sector result) => Result = result;

        public void SetResults(IEnumerable<Sector> results) => _results = results.ToList();
    }
}
