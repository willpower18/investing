using Investing.Domain.Repositories;
using Investing.Infrastructure.Entities;
using Investing.Shared.GlobalEnumerators;
using Investing.Shared.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Investing.Repository.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapping<Domain.Entities.Wallet, Infrastructure.Entities.Wallet> _map;

        public WalletRepository(ApplicationDbContext context, IMapping<Domain.Entities.Wallet, Infrastructure.Entities.Wallet> map)
        {
            _context = context;
            _map = map;
        }

        public async Task<IEnumerable<Domain.Entities.Wallet>> GetActiveRecords(CancellationToken cancellationToken = default)
        {
            var wallet = await _context.Wallet
              .Where(a => a.Active == (int)EActiveStatus.Active)
              .AsNoTracking()
              .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(wallet);
        }

        public async Task<IEnumerable<Domain.Entities.Wallet>> GetByAssetClassId(Guid assetClassId, CancellationToken cancellationToken = default)
        {
            var wallet = await _context.Wallet
                .Where(a =>
                    a.AssetClassId == assetClassId.ToString() &&
                    a.Active == (int)EActiveStatus.Active)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _map.MapListFromInfrastructureToDomain(wallet);
        }

        public async Task<Domain.Entities.Wallet> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var wallet = await _context.Wallet
               .Where(a => a.Id == id.ToString())
               .AsNoTracking()
               .FirstOrDefaultAsync(cancellationToken);

            if (wallet == null)
                return null;

            return _map.MapFromInfrastructureToDomain(wallet);
        }

        public async Task Create(Domain.Entities.Wallet entity, CancellationToken cancellationToken = default)
        {
            var wallet = _map.MapFromDomainToInfrastructure(entity);
            _context.Wallet.Add(wallet);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Domain.Entities.Wallet entity, CancellationToken cancellationToken = default)
        {
            var wallet = _map.MapFromDomainToInfrastructure(entity);
            _context.Wallet.Update(wallet);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Inactivate(Domain.Entities.Wallet entity, CancellationToken cancellationToken = default)
        {
            entity.Disable();
            await Update(entity, cancellationToken);
        }
    }
}
