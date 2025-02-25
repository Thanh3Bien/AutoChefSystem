using AutoChefSystem.Services.Models.Location;
using AutoChefSystem.Services.Models.RobotType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface ILocationService
    {
        Task<MessageResponse<LocationResponse?>> GetByIdAsync(int id);
        Task<MessageResponse<PaginatedLocationResponse>> GetAllAsync(int pageNumber, int pageSize);
        Task<MessageResponse<LocationResponse>> CreateAsync(CreateLocationRequest request);
        Task<MessageResponse<LocationResponse?>> UpdateAsync(int id, UpdateLocationRequest request);
        Task<MessageResponse<bool>> DeleteAsync(int id);
    }
}
