using AutoChefSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location?> GetByIdAsync(int id);
        Task<List<Location>> GetAllLocationsAsync(int pageNumber, int pageSize);
        Task AddLocationAsync(Location location);
        Task UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(int id);
    }
}
