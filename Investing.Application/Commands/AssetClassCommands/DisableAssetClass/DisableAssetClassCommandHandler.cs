using Investing.Application.Interfaces.Commands;
using Investing.Domain.Entities;
using Investing.Domain.Repositories;

namespace Investing.Application.Commands.AssetClassCommands.DisableAssetClass
{
    public sealed class DisableAssetClassCommandHandler : ICommandHandler<DisableAssetClassCommand, DisableAssetClassResult>
    {
        private readonly IAssetClassRepository _repository;

        public DisableAssetClassCommandHandler(IAssetClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<DisableAssetClassResult> Handle(DisableAssetClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new DisableAssetClassResult("Error!", request.GetErrorList());

                AssetClass assetClass = await _repository.GetById(request.AssetClassId, cancellationToken);
                if (assetClass == null)
                    return new DisableAssetClassResult("Error!", new List<string>() { "Asset Class not found" });

                await _repository.Inactivate(assetClass, cancellationToken);
                return new DisableAssetClassResult("OK!");
            }
            catch (Exception ex) 
            {
                return new DisableAssetClassResult("Error!", new List<string>() { ex.Message });
            }
        }
    }
}
