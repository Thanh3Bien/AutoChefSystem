using AutoChefSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRobotStepTaskRepository
    {
        Task<List<RobotStepTask>> GetAllAsync(int pageNumber, int pageSize);
        Task<RobotStepTask?> GetByIdAsync(int id);
        Task CreateAsync(RobotStepTask entity);
        Task UpdateAsync(RobotStepTask entity);
        Task DeleteAsync(int id);
    }
}
