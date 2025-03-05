using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> LoginAsync(string userName, string password);
        Task<User?> GetUserByFirebaseIdAsync(string email);
        Task<(IEnumerable<User>, int)> GetAllAsync(int pageNumber, int pageSize);
    }
}
