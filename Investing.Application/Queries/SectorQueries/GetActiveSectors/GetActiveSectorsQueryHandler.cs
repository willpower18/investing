using Investing.Application.Interfaces.Queries;
using Investing.Domain.Repositories;

namespace Investing.Application.Queries.SectorQueries.GetActiveSectors
{
    public sealed class GetActiveSectorsQueryHandler : IQueryHandler<GetActiveSectorsQuery, GetActiveSectorsResult>
    {
        private readonly ISectorRepository _sectorRepository;

        public GetActiveSectorsQueryHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<GetActiveSectorsResult> Handle(GetActiveSectorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new GetActiveSectorsResult("Erro", request.GetErrorList());

                var sectors = await _sectorRepository.GetActiveSectorsWithAssetClass(cancellationToken);
                var result = new GetActiveSectorsResult("Sucesso!");
                result.AddEntitiesToResult(sectors);
                return result;
            }
            catch (Exception ex)
            {
                return new GetActiveSectorsResult("Erro", new List<string>() { ex.Message });
            }
        }
    }
}
