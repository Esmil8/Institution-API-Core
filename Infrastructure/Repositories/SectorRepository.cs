using Institution.Domain.Entities;
using Institution.Domain.Interfaces;
using Institution.Infrastructure.Context;
using Institution.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace Institution.Infrastructure.Repositories
{
    public class SectorRepository(ApplicationDataContext context) 
        : BaseRepository<Sector>(context), ISectorRepository
    {
        public async Task<IEnumerable<Sector>> GetSectorsWithMunicipalityAsync()
        {
            return await _context.Sectors
                .Include(s => s.Municipality)
                .ToListAsync();
        }
    }
}