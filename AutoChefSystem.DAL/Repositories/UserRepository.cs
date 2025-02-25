using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories;
using AutoChefSystem.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoChefSystem.Repositories.Interfaces;

namespace AutoChefSystem.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

        public async Task<User?> LoginAsync(string userName, string password)
        {
            try
            {
                var account = await _dbSet.Where(a => a.UserName == userName && a.Password == password)
                                          .Include(u => u.Role)
                                          .FirstOrDefaultAsync();
                if (account != null)
                {
                    return account;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} LoginAsync method error", typeof(UserRepository));
                return new User();
            }
        }
    }
}
