using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        //public static RoleRepository instance { get; private set; }
        //private static object lockObject = new object();
        //private readonly AutoChefSystemContext _autoChefSystemContext;
        public RoleRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

        //public static RoleRepository Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new RoleRepository(context:, logger:);
        //        }
        //        return instance;
        //    }
        //}

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<IEnumerable<Role>> GetAllRolesAsync(int pageNumber, int pageSize)
        {
            return await _context.Roles
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _context.Roles.CountAsync();
        }
    }
}
