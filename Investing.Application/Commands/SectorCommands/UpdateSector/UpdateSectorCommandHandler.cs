using Investing.Application.Interfaces.Commands;
using Investing.Domain.Repositories;

namespace Investing.Application.Commands.SectorCommands.UpdateSector
{
    public sealed class UpdateSectorCommandHandler : ICommandHandler<UpdateSectorCommand, UpdateSectorResult>
    {
        private readonly ISectorRepository _sectorRepository;

        public UpdateSectorCommandHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<UpdateSectorResult> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new UpdateSectorResult("Error", request.GetErrorList());

                if (!request.Sector.IsValid)
                    return new UpdateSectorResult("Error", request.Sector.GetNotificationsList());

                await _sectorRepository.Update(request.Sector, cancellationToken);

                return new UpdateSectorResult("Success");
            }
            catch (Exception ex)
            {
                return new UpdateSectorResult("Error", new List<string>() { ex.Message });
            }
        }
    }
}
