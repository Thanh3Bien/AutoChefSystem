using AutoChefSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRobotRepository
    {
        Task<IEnumerable<Robot>> GetAllAsync(int pageNumber, int pageSize);
        Task<Robot?> GetByIdAsync(int id);
        Task<int> GetTotalCountAsync();
        Task AddAsync(Robot robot);
        Task UpdateAsync(Robot robot);
        Task DeleteAsync(int id);
    }
}
