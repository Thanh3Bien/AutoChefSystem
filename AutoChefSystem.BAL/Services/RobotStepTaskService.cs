using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RobotStepTask;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class RobotStepTaskService : IRobotStepTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RobotStepTaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageResponse<PaginatedRobotStepTaskResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            var tasks = await _unitOfWork.RobotStepTasks.GetAllAsync(pageNumber, pageSize);
            var mappedTasks = _mapper.Map<List<RobotStepTaskResponse>>(tasks);

            var result = new PaginatedRobotStepTaskResponse
            {
                Tasks = mappedTasks,
                Page = pageNumber,
                PageSize = pageSize
            };

            return new MessageResponse<PaginatedRobotStepTaskResponse>("Fetched all robot step tasks", result);
        }

        public async Task<MessageResponse<RobotStepTaskResponse?>> GetByIdAsync(int id)
        {
            var task = await _unitOfWork.RobotStepTasks.GetByIdAsync(id);
            if (task == null)
                return new MessageResponse<RobotStepTaskResponse?>("Task not found", null);

            var mappedTask = _mapper.Map<RobotStepTaskResponse>(task);
            return new MessageResponse<RobotStepTaskResponse?>("Task found", mappedTask);
        }

        public async Task<MessageResponse<RobotStepTaskResponse>> CreateAsync(CreateRobotStepTaskRequest request)
        {
            var task = new RobotStepTask
            {
                StepTaskId = request.StepTaskId,
                StepId = request.StepId,
                TaskDescription = request.TaskDescription,
                TaskOrder = request.TaskOrder,
                EstimatedTime = TimeOnly.Parse(request.EstimatedTime), // Chuyển đổi từ chuỗi sang TimeOnly
                RepeatCount = request.RepeatCount
            };

            await _unitOfWork.RobotStepTasks.CreateAsync(task);
            await _unitOfWork.CompleteAsync();

            var mappedTask = _mapper.Map<RobotStepTaskResponse>(task);
            return new MessageResponse<RobotStepTaskResponse>("Task created successfully", mappedTask);
        }


        public async Task<MessageResponse<RobotStepTaskResponse?>> UpdateAsync(int id, UpdateRobotStepTaskRequest request)
        {
            var task = await _unitOfWork.RobotStepTasks.GetByIdAsync(id);
            if (task == null)
                return new MessageResponse<RobotStepTaskResponse?>("Task not found", null);

            _mapper.Map(request, task);

            // Xử lý EstimatedTime từ chuỗi sang TimeOnly
            if (TimeOnly.TryParse(request.EstimatedTime, out var estimatedTime))
            {
                task.EstimatedTime = estimatedTime;
            }
            else
            {
                return new MessageResponse<RobotStepTaskResponse?>("Invalid EstimatedTime format", null);
            }

            await _unitOfWork.RobotStepTasks.UpdateAsync(task);
            await _unitOfWork.CompleteAsync();

            var mappedTask = _mapper.Map<RobotStepTaskResponse>(task);
            return new MessageResponse<RobotStepTaskResponse?>("Task updated successfully", mappedTask);
        }


        public async Task<MessageResponse<bool>> DeleteAsync(int id)
        {
            var task = await _unitOfWork.RobotStepTasks.GetByIdAsync(id);
            if (task == null)
                return new MessageResponse<bool>("Task not found", false);

            await _unitOfWork.RobotStepTasks.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<bool>("Task deleted successfully", true);
        }
    }
}
