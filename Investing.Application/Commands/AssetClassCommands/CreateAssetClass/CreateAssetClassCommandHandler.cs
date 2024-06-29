using Investing.Application.Interfaces.Commands;
using Investing.Domain.Repositories;

namespace Investing.Application.Commands.AssetClassCommands.CreateAssetClass
{
    public sealed class CreateAssetClassCommandHandler : ICommandHandler<CreateAssetClassCommand, CreateAssetClassResult>
    {
        private readonly IAssetClassRepository _repository;

        public CreateAssetClassCommandHandler(IAssetClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateAssetClassResult> Handle(CreateAssetClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return new CreateAssetClassResult("Error!", request.GetErrorList());

                if(!request.AssetClass.IsValid)
                    return new CreateAssetClassResult("Error!", request.AssetClass.GetNotificationsList());

                await _repository.Create(request.AssetClass, cancellationToken);
                return new CreateAssetClassResult("OK!");
            }
            catch (Exception ex)
            {
                return new CreateAssetClassResult("Error!", new List<string>() { ex.Message });
            }
        }
    }
}
