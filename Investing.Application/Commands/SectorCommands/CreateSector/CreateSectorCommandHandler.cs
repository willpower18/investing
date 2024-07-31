using Investing.Application.Interfaces.Commands;
using Investing.Domain.Repositories;

namespace Investing.Application.Commands.SectorCommands.CreateSector
{
    public sealed class CreateSectorCommandHandler : ICommandHandler<CreateSectorCommand, CreateSectorResult>
    {
        private readonly ISectorRepository _sectorRepository;
       
        public async Task<CreateSectorResult> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new CreateSectorResult("Error", request.GetErrorList());

                if (!request.Sector.IsValid)
                    return new CreateSectorResult("Error", request.Sector.GetNotificationsList());

                await _sectorRepository.Create(request.Sector, cancellationToken);

                return new CreateSectorResult("Success");
            }
            catch (Exception ex)
            {
                return new CreateSectorResult("Error", new List<string>() { ex.Message });
            }
        }
    }
}
