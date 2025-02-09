using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoChefSystem.DAL.Repositories
{
    public class RoleRepository
    {
        public static RoleRepository instance { get; private set; }
        private static object lockObject = new object();
        public RoleRepository() { }
        public static RoleRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleRepository();
                }
                return instance;
            }
        }

        public async Task<List<Role>> GetAllAsync()
        {
            using var db = new AutoChefSystemContext();
            return await db.Roles.ToListAsync();
        }
    }

    

}
