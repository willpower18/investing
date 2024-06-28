using Investing.Domain.Repositories;
using Investing.Infrastructure.Entities;
using Investing.Shared.GlobalEnumerators;
using Investing.Shared.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Investing.Repository.Repositories
{
    public class SectorConfigurationRepository : ISectorConfigurationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapping<Domain.Entities.SectorConfiguration, Infrastructure.Entities.SectorConfiguration> _map;

        public SectorConfigurationRepository(ApplicationDbContext context, IMapping<Domain.Entities.SectorConfiguration, Infrastructure.Entities.SectorConfiguration> map)
        {
            _context = context;
            _map = map;
        }       

        public async Task<IEnumerable<Domain.Entities.SectorConfiguration>> GetActiveRecords(CancellationToken cancellationToken = default)
        {
            var sectorCongirutarions = await _context.SectorConfiguration
               .Where(a => a.Active == (int)EActiveStatus.Active)
               .AsNoTracking()
               .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(sectorCongirutarions);
        }

        public async Task<IEnumerable<Domain.Entities.SectorConfiguration>> GetByAssetClassAndSectorId(Guid assetClassId, Guid sectorId, CancellationToken cancellationToken = default)
        {
            var sectorCongirutarions = await _context.SectorConfiguration
                .Where(a =>
                    a.AssetClassId == assetClassId.ToString() &&
                    a.SectorId == sectorId.ToString() &&
                    a.Active == (int)EActiveStatus.Active)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(sectorCongirutarions);
        }

        public async Task<IEnumerable<Domain.Entities.SectorConfiguration>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default)
        {
            var sectorCongirutarions = await _context.SectorConfiguration
                .Where(a =>
                    a.AssetClassId == assetClassId.ToString() &&
                    a.Active == (int)EActiveStatus.Active)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(sectorCongirutarions);
        }

        public async Task<Domain.Entities.SectorConfiguration> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var sectorCongirutarion = await _context.SectorConfiguration
                .Where(a => a.Id == id.ToString())
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (sectorCongirutarion == null)
                return null;

            return _map.MapFromInfrastructureToDomain(sectorCongirutarion);
        }

        public async Task<IEnumerable<Domain.Entities.SectorConfiguration>> GetBySectorId(Guid sectorId, CancellationToken cancellationToken = default)
        {
            var sectorCongirutarions = await _context.SectorConfiguration
               .Where(a =>
                   a.SectorId == sectorId.ToString() &&
                   a.Active == (int)EActiveStatus.Active)
               .AsNoTracking()
               .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(sectorCongirutarions);
        }

        public async Task Create(Domain.Entities.SectorConfiguration entity, CancellationToken cancellationToken = default)
        {
            var sectorConfig = _map.MapFromDomainToInfrastructure(entity);
            _context.SectorConfiguration.Add(sectorConfig);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Domain.Entities.SectorConfiguration entity, CancellationToken cancellationToken = default)
        {
            var sectorConfig = _map.MapFromDomainToInfrastructure(entity);
            _context.SectorConfiguration.Update(sectorConfig);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Inactivate(Domain.Entities.SectorConfiguration entity, CancellationToken cancellationToken = default)
        {
            entity.Disable();
            await Update(entity, cancellationToken);
        }
    }
}
