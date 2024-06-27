using AutoMapper;
using Investing.Shared.Mappings;

namespace Investing.Repository.Mappings
{
    public class SectorMapping : IMapping<Domain.Entities.Sector, Infrastructure.Entities.Sector>
    {
        private readonly IRepositoryMapping _repositoryMapping;
        private readonly IMapper _mapper;

        public SectorMapping(IRepositoryMapping repositoryMapping)
        {
            _repositoryMapping = repositoryMapping;
            _mapper = _repositoryMapping.GetMapper();
        }

        public Infrastructure.Entities.Sector MapFromDomainToInfrastructure(Domain.Entities.Sector domainEntity)
        {
            return _mapper.Map<Infrastructure.Entities.Sector>(domainEntity);
        }

        public Domain.Entities.Sector MapFromInfrastructureToDomain(Infrastructure.Entities.Sector infrastructureEntity)
        {
            return _mapper.Map<Domain.Entities.Sector>(infrastructureEntity);
        }

        public IEnumerable<Domain.Entities.Sector> MapListFromInfrastructureToDomain(IEnumerable<Infrastructure.Entities.Sector> listOfEntities)
        {
            List<Domain.Entities.Sector> entities = new List<Domain.Entities.Sector>();
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
