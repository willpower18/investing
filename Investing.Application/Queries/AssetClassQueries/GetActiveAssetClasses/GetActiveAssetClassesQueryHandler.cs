using Investing.Application.Interfaces.Queries;
using Investing.Domain.Entities;
using Investing.Domain.Repositories;

namespace Investing.Application.Queries.AssetClassQueries.GetActiveAssetClasses
{
    public sealed class GetActiveAssetClassesQueryHandler : IQueryHandler<GetActiveAssetClassesQuery, GetActiveAssetClassesResult>
    {
        private readonly IAssetClassRepository _repository;

        public GetActiveAssetClassesQueryHandler(IAssetClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetActiveAssetClassesResult> Handle(GetActiveAssetClassesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new GetActiveAssetClassesResult("Erro", request.GetErrorList());

                IEnumerable<AssetClass> assetClass = await _repository.GetActiveRecords(cancellationToken);

                var result = new GetActiveAssetClassesResult("Success!");
                result.AddEntitiesToResult(assetClass);
                return result;
            }
            catch (Exception ex)
            {
                return new GetActiveAssetClassesResult("Error!", new List<string>() { ex.Message });
            }
        }
    }
}
