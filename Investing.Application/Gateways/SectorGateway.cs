using Investing.Application.Commands.SectorCommands.CreateSector;
using Investing.Application.Commands.SectorCommands.DisableSector;
using Investing.Application.Commands.SectorCommands.UpdateSector;
using Investing.Application.Gateways.DefaultResults;
using Investing.Application.Gateways.Results;
using Investing.Application.Interfaces.Gateways;
using Investing.Application.Queries.SectorQueries.GetActiveSectors;
using Investing.Application.Queries.SectorQueries.GetSectorById;
using Investing.Domain.Entities;
using MediatR;

namespace Investing.Application.Gateways
{
    public class SectorGateway : IApplicationServiceGateway<Sector>
    {
        private readonly IMediator _mediator;

        public SectorGateway(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IApplicationServiceCommandResult> Create(Sector entity)
        {
            var command = new CreateSectorCommand(entity);
            var result = await _mediator.Send(command);
            if (!result.Succed)
                return new DefaultCommandResult(result.Message, result.Errors);

            return new DefaultCommandResult(result.Message);
        }

        public async Task<IApplicationServiceQueryResult<Sector>> GetActiveRecords()
        {
            var query = new GetActiveSectorsQuery();
            var result = await _mediator.Send(query);
            if (!result.Succed)
                return new SectorGatewayResult(result.Message, result.Errors);

            var gatewayResult = new SectorGatewayResult(result.Message);
            gatewayResult.SetResults(result.Results);
            return gatewayResult;
        }

        public async Task<IApplicationServiceQueryResult<Sector>> GetById(Guid id)
        {
            var query = new GetSectorByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.Succed)
                return new SectorGatewayResult(result.Message, result.Errors);

            var gatewayResult = new SectorGatewayResult(result.Message);
            gatewayResult.SetResult(result.Result);
            return gatewayResult;
        }

        public async Task<IApplicationServiceCommandResult> Inactivate(Guid id)
        {
            var command = new DisableSectorCommand(id);
            var result = await _mediator.Send(command);
            if (!result.Succed)
                return new DefaultCommandResult(result.Message, result.Errors);

            return new DefaultCommandResult(result.Message);
        }

        public async Task<IApplicationServiceCommandResult> Update(Sector entity)
        {
            var command = new UpdateSectorCommand(entity);
            var result = await _mediator.Send(command);
            if (!result.Succed)
                return new DefaultCommandResult(result.Message, result.Errors);

            return new DefaultCommandResult(result.Message);
        }
    }
}
