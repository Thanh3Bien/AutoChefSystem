using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Models.Roles;


namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRoleService
    {
        Task<CreateRoleRequest> AddAsync(CreateRoleRequest createRoleRequest);
    }
}
