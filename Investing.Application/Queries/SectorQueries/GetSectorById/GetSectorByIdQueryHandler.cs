using Investing.Application.Interfaces.Queries;
using Investing.Domain.Repositories;

namespace Investing.Application.Queries.SectorQueries.GetSectorById
{
    public sealed class GetSectorByIdQueryHandler : IQueryHandler<GetSectorByIdQuery, GetSectorByIdResult>
    {
        private readonly ISectorRepository _sectorRepository;

        public GetSectorByIdQueryHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<GetSectorByIdResult> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new GetSectorByIdResult("Erro", request.GetErrorList());

                var sector = await _sectorRepository.GetById(request.SectorId, cancellationToken);
                if (sector == null)
                    return null;

                var result = new GetSectorByIdResult("Sucesso!");
                result.AddEntityToResult(sector);
                return result;
            }
            catch (Exception ex)
            {
                return new GetSectorByIdResult("Erro", new List<string>() { ex.Message });
            }
        }
    }
}
