using AutoChefSystem.DAL;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(AutoChefSystemContext context, ILogger logger)
            : base(context, logger)
        {
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _context.Locations.FirstOrDefaultAsync(l => l.LocationId == id);
        }

        public async Task<List<Location>> GetAllLocationsAsync(int pageNumber, int pageSize)
        {
            return await _context.Locations
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddLocationAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                location.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
