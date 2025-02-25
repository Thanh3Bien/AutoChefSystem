using AutoChefSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRobotTypeRepository
    {
        Task<IEnumerable<RobotType>> GetAllRobotTypesAsync(int pageNumber, int pageSize);
        Task<RobotType?> GetByIdAsync(int id);
        Task AddRobotTypeAsync(RobotType robotType);
        Task UpdateRobotTypeAsync(RobotType robotType);
        Task DeleteRobotTypeAsync(int id);
    }
}
