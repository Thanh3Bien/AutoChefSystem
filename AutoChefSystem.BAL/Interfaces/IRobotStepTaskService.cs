using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Services.Models.RobotStepTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRobotStepTaskService
    {
        Task<MessageResponse<PaginatedRobotStepTaskResponse>> GetAllAsync(int pageNumber, int pageSize);
        Task<MessageResponse<RobotStepTaskResponse?>> GetByIdAsync(int id);
        Task<MessageResponse<RobotStepTaskResponse>> CreateAsync(CreateRobotStepTaskRequest request);
        Task<MessageResponse<RobotStepTaskResponse?>> UpdateAsync(int id, UpdateRobotStepTaskRequest request);
        Task<MessageResponse<bool>> DeleteAsync(int id);
    }
}
