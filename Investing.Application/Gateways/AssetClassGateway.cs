using Investing.Application.Commands.AssetClassCommands.CreateAssetClass;
using Investing.Application.Commands.AssetClassCommands.DisableAssetClass;
using Investing.Application.Commands.AssetClassCommands.UpdateAssetClass;
using Investing.Application.Gateways.DefaultResults;
using Investing.Application.Gateways.Results;
using Investing.Application.Interfaces.Gateways;
using Investing.Application.Queries.AssetClassQueries.GetActiveAssetClasses;
using Investing.Application.Queries.AssetClassQueries.GetAssetClassById;
using Investing.Domain.Entities;
using MediatR;

namespace Investing.Application.Gateways
{
    public sealed class AssetClassGateway : IApplicationServiceGateway<AssetClass>
    {
        private readonly IMediator _mediator;

        public AssetClassGateway(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IApplicationServiceCommandResult> Create(AssetClass entity)
        {
            var command = new CreateAssetClassCommand(entity);
            var result = await _mediator.Send(command);
            if (!result.Succed)
                return new DefaultCommandResult(result.Message, result.Errors);

            return new DefaultCommandResult(result.Message);
        }

        public async Task<IApplicationServiceQueryResult<AssetClass>> GetActiveRecords()
        {
            var query = new GetActiveAssetClassesQuery();
            var result = await _mediator.Send(query);
            if (!result.Succed)
                return new AssetClassGatewayResult(result.Message, result.Errors);

            var gatewayResult = new AssetClassGatewayResult(result.Message);
            gatewayResult.SetResults(result.Results);
            return gatewayResult;
        }

        public async Task<IApplicationServiceQueryResult<AssetClass>> GetById(Guid id)
        {
            var query = new GetAssetClassByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.Succed)
                return new AssetClassGatewayResult(result.Message, result.Errors);

            var gatewayResult = new AssetClassGatewayResult(result.Message);
            gatewayResult.SetResult(result.Result);
            return gatewayResult;
        }

        public async Task<IApplicationServiceCommandResult> Inactivate(Guid id)
        {
            var command = new DisableAssetClassCommand(id);
            var result = await _mediator.Send(command);
            if (!result.Succed)
                return new DefaultCommandResult(result.Message, result.Errors);

            return new DefaultCommandResult(result.Message);
        }

        public async Task<IApplicationServiceCommandResult> Update(AssetClass entity)
        {
            var command = new UpdateAssetClassCommand(entity);
            var result = await _mediator.Send(command);
            if (!result.Succed)
                return new DefaultCommandResult(result.Message, result.Errors);

            return new DefaultCommandResult(result.Message);
        }
    }
}
