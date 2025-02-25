using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RobotType;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class RobotTypeService : IRobotTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RobotTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageResponse<RobotTypeResponse?>> GetByIdAsync(int id)
        {
            var robotType = await _unitOfWork.RobotTypes.GetByIdAsync(id);
            if (robotType == null)
                return new MessageResponse<RobotTypeResponse?>("Robot type not found", null);

            return new MessageResponse<RobotTypeResponse?>("Robot type found", _mapper.Map<RobotTypeResponse>(robotType));
        }

        public async Task<MessageResponse<PaginatedRobotTypeResponse<RobotTypeResponse>>> GetAllAsync(int pageNumber, int pageSize)
        {
            var robotTypes = await _unitOfWork.RobotTypes.GetAllRobotTypesAsync(pageNumber, pageSize);

            var mappedList = _mapper.Map<List<RobotTypeResponse>>(robotTypes);

            var result = new PaginatedRobotTypeResponse<RobotTypeResponse>
            {
                RobotTypes = mappedList,
                Page = pageNumber,
                PageSize = pageSize,
            };

            return new MessageResponse<PaginatedRobotTypeResponse<RobotTypeResponse>>("Fetched all robot types", result);
        }
        public async Task<MessageResponse<RobotTypeResponse>> CreateAsync(CreateRobotTypeRequest request)
        {
            var robotType = new RobotType
            {
                RobotTypeName = request.RobotTypeName,
                Description = request.Description
            };

            await _unitOfWork.RobotTypes.AddRobotTypeAsync(robotType);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<RobotTypeResponse>("Robot type created successfully", _mapper.Map<RobotTypeResponse>(robotType));
        }

        public async Task<MessageResponse<RobotTypeResponse?>> UpdateAsync(int id, UpdateRobotTypeRequest request)
        {
            var existingRobotType = await _unitOfWork.RobotTypes.GetByIdAsync(id);
            if (existingRobotType == null)
                return new MessageResponse<RobotTypeResponse?>("Robot type not found", null);

            existingRobotType.RobotTypeName = request.RobotTypeName;
            existingRobotType.Description = request.Description;

            await _unitOfWork.RobotTypes.UpdateRobotTypeAsync(existingRobotType);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<RobotTypeResponse?>("Robot type updated successfully", _mapper.Map<RobotTypeResponse>(existingRobotType));
        }

        public async Task<MessageResponse<bool>> DeleteAsync(int id)
        {
            var robotType = await _unitOfWork.RobotTypes.GetByIdAsync(id);
            if (robotType == null)
                return new MessageResponse<bool>("Robot type not found", false);

            await _unitOfWork.RobotTypes.DeleteRobotTypeAsync(id);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<bool>("Robot type deleted successfully", true);
        }
    }
}
