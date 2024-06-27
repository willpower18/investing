using AutoMapper;
using Investing.Shared.Mappings;

namespace Investing.Repository.Mappings
{
    public class SectorConfigurationMapping : IMapping<Domain.Entities.SectorConfiguration, Infrastructure.Entities.SectorConfiguration>
    {
        private readonly IRepositoryMapping _repositoryMapping;
        private readonly IMapper _mapper;

        public SectorConfigurationMapping(IRepositoryMapping repositoryMapping)
        {
            _repositoryMapping = repositoryMapping;
            _mapper = _repositoryMapping.GetMapper();
        }

        public Infrastructure.Entities.SectorConfiguration MapFromDomainToInfrastructure(Domain.Entities.SectorConfiguration domainEntity)
        {
            return _mapper.Map<Infrastructure.Entities.SectorConfiguration>(domainEntity);
        }

        public Domain.Entities.SectorConfiguration MapFromInfrastructureToDomain(Infrastructure.Entities.SectorConfiguration infrastructureEntity)
        {
            return _mapper.Map<Domain.Entities.SectorConfiguration>(infrastructureEntity);
        }

        public IEnumerable<Domain.Entities.SectorConfiguration> MapListFromInfrastructureToDomain(IEnumerable<Infrastructure.Entities.SectorConfiguration> listOfEntities)
        {
            List<Domain.Entities.SectorConfiguration> entities = new List<Domain.Entities.SectorConfiguration>();
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
