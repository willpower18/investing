using Investing.Application.Interfaces.Commands;
using Investing.Domain.Repositories;

namespace Investing.Application.Commands.AssetClassCommands.UpdateAssetClass
{
    public sealed class UpdateAssetClassCommandHandler : ICommandHandler<UpdateAssetClassCommand, UpdateAssetClassResult>
    {
        private readonly IAssetClassRepository _repository;

        public UpdateAssetClassCommandHandler(IAssetClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateAssetClassResult> Handle(UpdateAssetClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new UpdateAssetClassResult("Error!", request.GetErrorList());

                if (!request.AssetClass.IsValid)
                    return new UpdateAssetClassResult("Error!", request.AssetClass.GetNotificationsList());

                await _repository.Update(request.AssetClass, cancellationToken);
                return new UpdateAssetClassResult("OK!");
            }
            catch (Exception ex)
            {
                return new UpdateAssetClassResult("Error!", new List<string>() { ex.Message });
            }
        }
    }
}
