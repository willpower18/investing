using AutoMapper;
using Investing.Shared.Mappings;

namespace Investing.Repository.Mappings
{
    public class WalletMapping : IMapping<Domain.Entities.Wallet, Infrastructure.Entities.Wallet>
    {
        private readonly IRepositoryMapping _repositoryMapping;
        private readonly IMapper _mapper;

        public WalletMapping(IRepositoryMapping repositoryMapping)
        {
            _repositoryMapping = repositoryMapping;
            _mapper = _repositoryMapping.GetMapper();
        }

        public Infrastructure.Entities.Wallet MapFromDomainToInfrastructure(Domain.Entities.Wallet domainEntity)
        {
            return _mapper.Map<Infrastructure.Entities.Wallet>(domainEntity);
        }

        public Domain.Entities.Wallet MapFromInfrastructureToDomain(Infrastructure.Entities.Wallet infrastructureEntity)
        {
            return _mapper.Map<Domain.Entities.Wallet>(infrastructureEntity);
        }

        public IEnumerable<Domain.Entities.Wallet> MapListFromInfrastructureToDomain(IEnumerable<Infrastructure.Entities.Wallet> listOfEntities)
        {
            List<Domain.Entities.Wallet> entities = new List<Domain.Entities.Wallet>();
            if (listOfEntities != null)
            {
                foreach (var entity in listOfEntities)
                {
                    entities.Add(MapFromInfrastructureToDomain(entity));
                }
            }

            return entities;
        }
    }
}
