using AutoMapper;
using Investing.Shared.Mappings;

namespace Investing.Repository.Mappings
{
    public class AssetMapping : IMapping<Domain.Entities.Asset, Infrastructure.Entities.Asset>
    {
        private readonly IRepositoryMapping _repositoryMapping;
        private readonly IMapper _mapper;

        public AssetMapping(IRepositoryMapping repositoryMapping)
        {
            _repositoryMapping = repositoryMapping;
            _mapper = _repositoryMapping.GetMapper();
        }

        public Infrastructure.Entities.Asset MapFromDomainToInfrastructure(Domain.Entities.Asset domainEntity)
        {
            return _mapper.Map<Infrastructure.Entities.Asset>(domainEntity);
        }

        public Domain.Entities.Asset MapFromInfrastructureToDomain(Infrastructure.Entities.Asset infrastructureEntity)
        {
            return _mapper.Map<Domain.Entities.Asset>(infrastructureEntity);
        }

        public IEnumerable<Domain.Entities.Asset> MapListFromInfrastructureToDomain(IEnumerable<Infrastructure.Entities.Asset> listOfEntities)
        {
            List<Domain.Entities.Asset> entities = new List<Domain.Entities.Asset>();
            if(listOfEntities != null)
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
