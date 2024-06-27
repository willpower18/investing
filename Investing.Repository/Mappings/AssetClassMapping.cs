using AutoMapper;
using Investing.Shared.Mappings;

namespace Investing.Repository.Mappings
{
    public class AssetClassMapping : IMapping<Domain.Entities.AssetClass, Infrastructure.Entities.AssetClass>
    {
        private readonly IRepositoryMapping _repositoryMapping;
        private readonly IMapper _mapper;

        public AssetClassMapping(IRepositoryMapping repositoryMapping)
        {
            _repositoryMapping = repositoryMapping;
            _mapper = _repositoryMapping.GetMapper();
        }

        public Infrastructure.Entities.AssetClass MapFromDomainToInfrastructure(Domain.Entities.AssetClass domainEntity)
        {
            return _mapper.Map<Infrastructure.Entities.AssetClass>(domainEntity);
        }

        public Domain.Entities.AssetClass MapFromInfrastructureToDomain(Infrastructure.Entities.AssetClass infrastructureEntity)
        {
            return _mapper.Map<Domain.Entities.AssetClass>(infrastructureEntity);
        }

        public IEnumerable<Domain.Entities.AssetClass> MapListFromInfrastructureToDomain(IEnumerable<Infrastructure.Entities.AssetClass> listOfEntities)
        {
            List<Domain.Entities.AssetClass> entities = new List<Domain.Entities.AssetClass>();
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
