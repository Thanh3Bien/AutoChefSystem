using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Repositories;

namespace AutoChefSystem.BAL.Services
{
    public class RoleService
    {
        public async Task<List<Role>> GetAll() => await RoleRepository.Instance.GetAllAsync();
    }
}
