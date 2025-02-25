using AutoChefSystem.Services.Models.Robots;
using AutoChefSystem.Services.Models.RobotType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRobotService
    {
        Task<MessageResponse<RobotResponse?>> GetByIdAsync(int id);
        Task<MessageResponse<PaginatedRobotResponse<RobotResponse>>> GetAllAsync(int pageNumber, int pageSize);
        Task<MessageResponse<RobotResponse>> CreateAsync(CreateRobotRequest request);
        Task<MessageResponse<RobotResponse?>> UpdateAsync(int id, UpdateRobotRequest request);
        Task<MessageResponse<bool>> DeleteAsync(int id);
    }
}
