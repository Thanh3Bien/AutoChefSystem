using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Interfaces;
using AutoChefSystem.BAL.Models.Roles;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.DAL.Repositories;

namespace AutoChefSystem.BAL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Role?> GetByIdAsync(int id) => await _unitOfWork.Roles.GetByIdAsync(id);

        public async Task<CreateRoleRequest> AddAsync(CreateRoleRequest createRoleRequest)
        {
            var role = new Role()
            {
                RoleName = createRoleRequest.RoleName,
            };
            var result = _unitOfWork.Roles.AddEntity(role);
            await _unitOfWork.CompleteAsync();
            return createRoleRequest;
        }
    }
}
