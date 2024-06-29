using Investing.Application.Gateways.CommandResults;
using Investing.Application.Interfaces.Gateways;
using Investing.Domain.Entities;

namespace Investing.Application.Gateways.Results
{
    public class AssetClassGatewayResult : DefaultResult, IApplicationServiceQueryResult<AssetClass>
    {
        private IList<AssetClass> _results = new List<AssetClass>();

        public AssetClassGatewayResult(string message) : base(message)
        {
        }

        public AssetClassGatewayResult(string message, IEnumerable<string> errors) : base(message, errors)
        {
        }

        public AssetClass Result { get; set; }

        public IReadOnlyCollection<AssetClass> Results => _results.ToArray();

        public void SetResult(AssetClass result) => Result = result;

        public void SetResults(IEnumerable<AssetClass> results) => _results = results.ToList();
    }
}
