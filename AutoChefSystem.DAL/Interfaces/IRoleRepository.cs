using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Entities;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<IEnumerable<Role>> GetAllRolesAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
    }
}
