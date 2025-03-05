using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.BAL.Models.Roles;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using AutoChefSystem.Services.Models.Roles;

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
            _unitOfWork.Roles.AddEntity(role);
            await _unitOfWork.CompleteAsync();
            return createRoleRequest;
        }
        public async Task<PagedResult<Role>> GetAllRolesAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("PageNumber and PageSize must be greater than zero.");
            }

            var roles = await _unitOfWork.Roles.GetAllRolesAsync(pageNumber, pageSize);
            var totalRoles = await _unitOfWork.Roles.CountAsync();

            return new PagedResult<Role>(roles, totalRoles);
        }
    }
}
