using Investing.Domain.Repositories;
using Investing.Infrastructure.Entities;
using Investing.Shared.GlobalEnumerators;
using Investing.Shared.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Investing.Repository.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapping<Domain.Entities.Sector, Infrastructure.Entities.Sector> _map;

        public SectorRepository(ApplicationDbContext context, IMapping<Domain.Entities.Sector, Infrastructure.Entities.Sector> map)
        {
            _context = context;
            _map = map;
        }

        public async Task<IEnumerable<Domain.Entities.Sector>> GetActiveRecords(CancellationToken cancellationToken = default)
        {
            var sectors = await _context.Sector
               .Where(a => a.Active == (int)EActiveStatus.Active)
               .AsNoTracking()
               .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(sectors);
        }

        public async Task<IEnumerable<Domain.Entities.Sector>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default)
        {
            var sectors = await _context.Sector
                .Where(a =>
                    a.AssetClassId == assetClassId.ToString() &&
                    a.Active == (int)EActiveStatus.Active)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(sectors);
        }

        public async Task<IEnumerable<Domain.Entities.Sector>> GetActiveSectorsWithAssetClass(CancellationToken cancellationToken = default)
        {
            var sectors = await _context.Sector
              .Where(a => a.Active == (int)EActiveStatus.Active)
              .AsNoTracking()
              .ToListAsync(cancellationToken);

            var assetClassesIds = sectors.Select(s => s.AssetClassId).ToList();
            var assetClasses = await _context.AssetClass.Where(a => assetClassesIds.Contains(a.Id)).AsNoTracking().ToListAsync(cancellationToken);

            List<Domain.Entities.Sector> sectorsWithDetails = new List<Domain.Entities.Sector>();
            AssetClass assetClass = null;
            Domain.Entities.Sector sector = null;
            foreach (var sectorInfra in sectors)
            {
                Guid.TryParse(sectorInfra.AssetClassId, out Guid assetClassId);
                Guid.TryParse(sectorInfra.Id, out Guid sectorId);
                assetClass = assetClasses.Where(a => a.Id == sectorInfra.AssetClassId).FirstOrDefault();
                sector = _map.MapFromInfrastructureToDomain(sectorInfra);
                if (assetClass != null)
                    sector.ProvideAssetClassName(assetClass.Name);

                sectorsWithDetails.Add(sector);
            }

            return sectorsWithDetails;
        }

        public async Task<Domain.Entities.Sector> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var sector = await _context.Sector
               .Where(a => a.Id == id.ToString())
               .AsNoTracking()
               .FirstOrDefaultAsync(cancellationToken);

            if (sector == null)
                return null;

            return _map.MapFromInfrastructureToDomain(sector);
        }

        public async Task Create(Domain.Entities.Sector entity, CancellationToken cancellationToken = default)
        {
            var sector = _map.MapFromDomainToInfrastructure(entity);
            _context.Sector.Add(sector);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Domain.Entities.Sector entity, CancellationToken cancellationToken = default)
        {
            var sector = _map.MapFromDomainToInfrastructure(entity);
            _context.Sector.Update(sector);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Inactivate(Domain.Entities.Sector entity, CancellationToken cancellationToken = default)
        {
            entity.Disable();
            await Update(entity, cancellationToken);
        }        
    }
}
