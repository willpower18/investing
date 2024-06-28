using Investing.Domain.Repositories;
using Investing.Infrastructure.Entities;
using Investing.Shared.GlobalEnumerators;
using Investing.Shared.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Investing.Repository.Repositories
{
    public class AssetClassRepository : IAssetClassRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapping<Domain.Entities.AssetClass, Infrastructure.Entities.AssetClass> _map;

        public AssetClassRepository(ApplicationDbContext context, IMapping<Domain.Entities.AssetClass, Infrastructure.Entities.AssetClass> map)
        {
            _context = context;
            _map = map;
        }        

        public async Task<IEnumerable<Domain.Entities.AssetClass>> GetActiveRecords(CancellationToken cancellationToken = default)
        {
            var assetClasses = await _context.AssetClass
               .Where(a => a.Active == (int)EActiveStatus.Active)
               .AsNoTracking()
               .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(assetClasses);
        }

        public async Task<Domain.Entities.AssetClass> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var assetClass = await _context.AssetClass
                .Where(a => a.Id == id.ToString())
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (assetClass == null)
                return null;

            return _map.MapFromInfrastructureToDomain(assetClass);
        }        

        public async Task Create(Domain.Entities.AssetClass entity, CancellationToken cancellationToken = default)
        {
            var assetClass = _map.MapFromDomainToInfrastructure(entity);
            _context.AssetClass.Add(assetClass);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Domain.Entities.AssetClass entity, CancellationToken cancellationToken = default)
        {
            var assetClass = _map.MapFromDomainToInfrastructure(entity);
            _context.AssetClass.Update(assetClass);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Inactivate(Domain.Entities.AssetClass entity, CancellationToken cancellationToken = default)
        {
            entity.Disable();
            await Update(entity, cancellationToken);
        }
    }
}