using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.DAL.Repositories;

namespace AutoChefSystem.BAL.Services
{
    public class RoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Role?> GetById(int id) => await _unitOfWork.Roles.GetByIdAsync(id);
    }
}
