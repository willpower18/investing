using Investing.Application.Interfaces.Commands;
using Investing.Domain.Entities;
using Investing.Domain.Repositories;

namespace Investing.Application.Commands.SectorCommands.DisableSector
{
    public sealed class DisableSectorCommandHandler : ICommandHandler<DisableSectorCommand, DisableSectorResult>
    {
        private readonly ISectorRepository _sectorRepository;

        public DisableSectorCommandHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<DisableSectorResult> Handle(DisableSectorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new DisableSectorResult("Error!", request.GetErrorList());

                Sector sector = await _sectorRepository.GetById(request.SectorId, cancellationToken);
                if (sector == null)
                    return new DisableSectorResult("Error!", new List<string>() { "Sector not found" });

                await _sectorRepository.Inactivate(sector, cancellationToken);
                return new DisableSectorResult("OK!");
            }
            catch (Exception ex)
            {
                return new DisableSectorResult("Error!", new List<string>() { ex.Message });
            }
        }
    }
}
