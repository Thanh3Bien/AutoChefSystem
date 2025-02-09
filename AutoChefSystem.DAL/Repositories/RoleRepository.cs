using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.DAL.Repositories
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
    }

    

}
