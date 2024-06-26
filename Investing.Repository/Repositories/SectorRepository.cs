﻿using Investing.Domain.Repositories;
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
