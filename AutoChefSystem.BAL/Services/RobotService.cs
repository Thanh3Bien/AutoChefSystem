using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Robots;
using AutoChefSystem.Services.Models.RobotType;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class RobotService : IRobotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RobotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageResponse<RobotResponse?>> GetByIdAsync(int id)
        {
            var robot = await _unitOfWork.Robots.GetByIdAsync(id);
            if (robot == null)
                return new MessageResponse<RobotResponse?>("Robot not found", null);

            var response = new RobotResponse
            {
                RobotId = robot.RobotId,
                RobotTypeId = robot.RobotTypeId,
                LocationId = robot.LocationId,
                IsActive = robot.IsActive,
                RobotTypeName = robot.RobotType?.RobotTypeName ?? "Unknown", 
                LocationName = robot.Location?.LocationName ?? "Unknown"    
            };

            return new MessageResponse<RobotResponse?>("Robot found", response);
        }

        public async Task<MessageResponse<PaginatedRobotResponse<RobotResponse>>> GetAllAsync(int pageNumber, int pageSize)
        {
            var robots = await _unitOfWork.Robots.GetAllAsync(pageNumber, pageSize);
            var totalRecords = await _unitOfWork.Robots.GetTotalCountAsync();

            var responseList = robots.Select(robot => new RobotResponse
            {
                RobotId = robot.RobotId,
                RobotTypeId = robot.RobotTypeId,
                LocationId = robot.LocationId,
                IsActive = robot.IsActive,
                RobotTypeName = robot.RobotType?.RobotTypeName ?? "Unknown", // Get RobotTypeName
                LocationName = robot.Location?.LocationName ?? "Unknown"    // Get LocationName
            }).ToList();

            var result = new PaginatedRobotResponse<RobotResponse>
            {
                Robot = responseList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };

            return new MessageResponse<PaginatedRobotResponse<RobotResponse>>("Fetched all robots", result);
        }

        public async Task<MessageResponse<RobotResponse>> CreateAsync(CreateRobotRequest request)
        {
            var robot = new Robot
            {
                RobotTypeId = request.RobotTypeId,
                LocationId = request.LocationId,
                IsActive = request.IsActive
            };

            await _unitOfWork.Robots.AddAsync(robot);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<RobotResponse>("Robot created successfully", _mapper.Map<RobotResponse>(robot));
        }

        public async Task<MessageResponse<RobotResponse?>> UpdateAsync(int id, UpdateRobotRequest request)
        {
            var existingRobot = await _unitOfWork.Robots.GetByIdAsync(id);
            if (existingRobot == null)
                return new MessageResponse<RobotResponse?>("Robot not found", null);

            existingRobot.RobotTypeId = request.RobotTypeId;
            existingRobot.LocationId = request.LocationId;
            existingRobot.IsActive = request.IsActive;

            await _unitOfWork.Robots.UpdateAsync(existingRobot);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<RobotResponse?>("Robot updated successfully", _mapper.Map<RobotResponse>(existingRobot));
        }

        public async Task<MessageResponse<bool>> DeleteAsync(int id)
        {
            var robot = await _unitOfWork.Robots.GetByIdAsync(id);
            if (robot == null)
                return new MessageResponse<bool>("Robot not found", false);

            await _unitOfWork.Robots.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<bool>("Robot deleted successfully", true);
        }
    }
}
