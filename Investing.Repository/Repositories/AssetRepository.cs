using Investing.Domain.Repositories;
using Investing.Infrastructure.Entities;
using Investing.Shared.GlobalEnumerators;
using Investing.Shared.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Investing.Repository.Repositories
{
    public class AssetRepository : IAssetRepository
    {        
        private readonly ApplicationDbContext _context;
        private readonly IMapping<Domain.Entities.Asset, Infrastructure.Entities.Asset> _map;

        public AssetRepository(ApplicationDbContext context, IMapping<Domain.Entities.Asset, Infrastructure.Entities.Asset> map)
        {
            _context = context;
            _map = map;
        }        

        public async Task<IEnumerable<Domain.Entities.Asset>> GetActiveRecords(CancellationToken cancellationToken = default)
        {
            var assets = await _context.Asset
                .Where(a => a.Active == (int)EActiveStatus.Active)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(assets);
        }

        public async Task<IEnumerable<Domain.Entities.Asset>> GetByAssetClassAndSectorId(Guid assetClassId, Guid sectorId, CancellationToken cancellationToken = default)
        {
            var assets = await _context.Asset
                .Where(a => 
                    a.AssetClassId == assetClassId.ToString() && 
                    a.SectorId == sectorId.ToString() && 
                    a.Active == (int)EActiveStatus.Active)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(assets);
        }

        public async Task<IEnumerable<Domain.Entities.Asset>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default)
        {
            var assets = await _context.Asset
                .Where(a =>
                    a.AssetClassId == assetClassId.ToString() &&
                    a.Active == (int)EActiveStatus.Active)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(assets);
        }        

        public async Task<IEnumerable<Domain.Entities.Asset>> GetBySectorId(Guid sectorId, CancellationToken cancellationToken = default)
        {
            var assets = await _context.Asset
               .Where(a =>
                   a.SectorId == sectorId.ToString() &&
                   a.Active == (int)EActiveStatus.Active)
               .AsNoTracking()
               .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(assets);
        }

        public async Task<Domain.Entities.Asset> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var asset = await _context.Asset
                .Where(a => a.Id == id.ToString())
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (asset == null)
                return null;

            return _map.MapFromInfrastructureToDomain(asset);
        }

        public async Task<Domain.Entities.Asset> GetByTicker(string ticker, CancellationToken cancellationToken = default)
        {
            var asset = await _context.Asset
                .Where(a => a.Ticker == ticker)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (asset == null)
                return null;

            return _map.MapFromInfrastructureToDomain(asset);
        }

        public async Task Create(Domain.Entities.Asset entity, CancellationToken cancellationToken = default)
        {
            var asset = _map.MapFromDomainToInfrastructure(entity);
            _context.Asset.Add(asset);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Domain.Entities.Asset entity, CancellationToken cancellationToken = default)
        {
            var asset = _map.MapFromDomainToInfrastructure(entity);
            _context.Asset.Update(asset);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Inactivate(Domain.Entities.Asset entity, CancellationToken cancellationToken = default)
        {
            entity.Disable();
            await Update(entity, cancellationToken);
        }
    }
}
