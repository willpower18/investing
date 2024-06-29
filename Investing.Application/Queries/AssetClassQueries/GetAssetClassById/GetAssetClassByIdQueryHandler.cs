using Investing.Application.Interfaces.Queries;
using Investing.Domain.Entities;
using Investing.Domain.Repositories;

namespace Investing.Application.Queries.AssetClassQueries.GetAssetClassById
{
    public sealed class GetAssetClassByIdQueryHandler : IQueryHandler<GetAssetClassByIdQuery, GetAssetClassByIdResult>
    {
        private readonly IAssetClassRepository _repository;

        public GetAssetClassByIdQueryHandler(IAssetClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAssetClassByIdResult> Handle(GetAssetClassByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new GetAssetClassByIdResult("Erro", request.GetErrorList());

                AssetClass assetClass = await _repository.GetById(request.AssetClassId, cancellationToken);
                if(assetClass == null)
                    return new GetAssetClassByIdResult("Error!", new List<string>() { "Asset Class not found" });

                var result = new GetAssetClassByIdResult("Success!");
                result.AddEntityToResult(assetClass);
                return result;
            }
            catch (Exception ex)
            {
                return new GetAssetClassByIdResult("Error!", new List<string>() { ex.Message });
            }
        }
    }
}
