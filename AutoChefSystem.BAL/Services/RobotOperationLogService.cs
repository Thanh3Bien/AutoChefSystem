using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RobotOperationLog;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class RobotOperationLogService : IRobotOperationLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RobotOperationLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageResponse<PaginatedRobotOperationLogResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            var logs = await _unitOfWork.RobotOperations.GetAllAsync(pageNumber, pageSize);
            var mappedList = _mapper.Map<List<RobotOperationLogResponse>>(logs);

            var result = new PaginatedRobotOperationLogResponse
            {
                Logs = mappedList,
                Page = pageNumber,
                PageSize = pageSize
            };

            return new MessageResponse<PaginatedRobotOperationLogResponse>("Fetched all robot operation logs", result);
        }

        public async Task<MessageResponse<List<RobotOperationLogResponse>>> GetByOrderIdAsync(int orderId)
        {
            var logs = await _unitOfWork.RobotOperations.GetByOrderIdAsync(orderId);
            if (logs == null || logs.Count == 0)
                return new MessageResponse<List<RobotOperationLogResponse>>("Logs not found", new List<RobotOperationLogResponse>());

            var mappedLogs = _mapper.Map<List<RobotOperationLogResponse>>(logs);
            return new MessageResponse<List<RobotOperationLogResponse>>("Logs found", mappedLogs);
        }


        //public async Task<MessageResponse<RobotOperationLogResponse>> CreateAsync(CreateRobotOperationLogRequest request)
        //{
        //    var log = new RobotOperationLog
        //    {
        //        OrderId = request.OrderId,
        //        RobotId = request.RobotId,
        //        StartTime = request.StartTime,
        //        EndTime = request.EndTime,
        //        CompletionStatus = request.CompletionStatus,
        //        OperationLog = request.OperationLog
        //    };

        //    await _unitOfWork.RobotOperations.CreateAsync(log);
        //    await _unitOfWork.CompleteAsync();

        //    var mappedLog = _mapper.Map<RobotOperationLogResponse>(log);
        //    return new MessageResponse<RobotOperationLogResponse>("Log created successfully", mappedLog);
        //}

        public async Task<RobotOperationLogResponse> CreateAsync(CreateRobotOperationLogRequest request)
        {
            var log = new RobotOperationLog
            {
                OrderId = request.OrderId,
                RobotId = request.RobotId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                CompletionStatus = request.CompletionStatus,
                OperationLog = request.OperationLog
            };
            var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
            if (order != null)
            {
                order.CompletedTime = DateTime.Now;
                await _unitOfWork.Orders.UpdateAsync(order);
            }
            await _unitOfWork.RobotOperations.CreateAsync(log);
            await _unitOfWork.CompleteAsync();

            var mappedLog = _mapper.Map<RobotOperationLogResponse>(log);
            return mappedLog;
        }

        public async Task<MessageResponse<RobotOperationLogResponse?>> UpdateAsync(int id, UpdateRobotOperationLogRequest request)
        {
            var existingLog = await _unitOfWork.RobotOperations.GetByIdAsync(id);
            if (existingLog == null)
                return new MessageResponse<RobotOperationLogResponse?>("Log not found", null);

            existingLog.OrderId = request.OrderId;
            existingLog.RobotId = request.RobotId;
            existingLog.StartTime = request.StartTime;
            existingLog.EndTime = request.EndTime;
            existingLog.CompletionStatus = request.CompletionStatus;
            existingLog.OperationLog = request.OperationLog;

            await _unitOfWork.RobotOperations.UpdateAsync(id, existingLog);
            await _unitOfWork.CompleteAsync();

            var mappedLog = _mapper.Map<RobotOperationLogResponse>(existingLog);
            return new MessageResponse<RobotOperationLogResponse?>("Log updated successfully", mappedLog);
        }

        public async Task<MessageResponse<bool>> DeleteAsync(int id)
        {
            var existingLog = await _unitOfWork.RobotOperations.GetByIdAsync(id);
            if (existingLog == null)
                return new MessageResponse<bool>("Log not found", false);

            await _unitOfWork.RobotOperations.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();

            return new MessageResponse<bool>("Log deleted successfully", true);
        }

        public async Task<MessageResponse<RobotOperationLogResponse?>> GetByIdAsync(int id)
        {
            var log = await _unitOfWork.RobotOperations.GetByIdAsync(id);
            if (log == null)
            {
                return new MessageResponse<RobotOperationLogResponse?>("Operation log not found", null);
            }

            var mappedLog = _mapper.Map<RobotOperationLogResponse>(log);
            return new MessageResponse<RobotOperationLogResponse?>("Fetched operation log", mappedLog);
        }
    }
}
