using AutoChefSystem.Services.Models.RobotType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRobotTypeService
    {
        Task<MessageResponse<PaginatedRobotTypeResponse<RobotTypeResponse>>> GetAllAsync(int pageNumber, int pageSize);
        Task<MessageResponse<RobotTypeResponse?>> GetByIdAsync(int id);
        Task<MessageResponse<RobotTypeResponse>> CreateAsync(CreateRobotTypeRequest request);
        Task<MessageResponse<RobotTypeResponse?>> UpdateAsync(int id, UpdateRobotTypeRequest request);
        Task<MessageResponse<bool>> DeleteAsync(int id);
    }
}
