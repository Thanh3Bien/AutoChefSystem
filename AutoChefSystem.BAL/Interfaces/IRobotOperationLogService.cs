using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Services.Models.RobotOperationLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRobotOperationLogService
    {
        Task<MessageResponse<PaginatedRobotOperationLogResponse>> GetAllAsync(int pageNumber, int pageSize);
        Task<MessageResponse<List<RobotOperationLogResponse>>> GetByOrderIdAsync(int orderId);
        Task<MessageResponse<RobotOperationLogResponse>> CreateAsync(CreateRobotOperationLogRequest request);
        Task<MessageResponse<RobotOperationLogResponse?>> UpdateAsync(int id, UpdateRobotOperationLogRequest request);
        Task<MessageResponse<bool>> DeleteAsync(int id);

        Task<MessageResponse<RobotOperationLogResponse?>> GetByIdAsync(int id);
    }
}
