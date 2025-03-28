﻿
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Order;
using AutoChefSystem.Services.Models.Recipe;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOrderRequest> CreateOrderAsync(CreateOrderRequest createOrders)
        {
            var order = _mapper.Map<Order>(createOrders);
            var createOrder = await _unitOfWork.Orders.CreateAsync(order);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CreateOrderRequest>(createOrder);
        }

        public async Task<GetOrderByIdResponse?> GetByIdAsync(int id)
        {

            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return null;
            }

            return _mapper.Map<GetOrderByIdResponse>(order);
        }

        public async Task<UpdateOrderRequest> UpdateAsync(UpdateOrderRequest updateOrder)
        {

            var existingOrder = await _unitOfWork.Orders.GetByIdAsync(updateOrder.OrderId);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }

            _mapper.Map(updateOrder, existingOrder);
            _unitOfWork.Orders.UpdateAsync(existingOrder);


            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UpdateOrderRequest>(existingOrder);
        }

        public async Task<PaginatedOrderResponse> GetAllOrdersAsync(bool sort, string? status, int page, int pageSize)
        {
            var (orders, totalCount) = await _unitOfWork.Orders.GetAllOdersAsync(sort, status, page, pageSize);
            var ordersList = _mapper.Map<List<GetAllOrderResponse>>(orders);

            return new PaginatedOrderResponse
            {
                Orders = ordersList,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
  

        public async Task<bool> UpdateOrderStatus(int orderId,  bool isCancel)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null)
            {
                return false; 
            }

            if (isCancel && order.Status == "Pending")
            {
                order.Status = "Canceled";
            }
            else { 

                switch (order.Status)
                {
                    case "Pending":
                        order.Status = "Waiting";
                        break;
                    case "Waiting":
                        order.Status = "Processing";
                        break;
                    case "Processing":
                        order.Status = "Complete";
                        break;
                    case "Complete":
                        return false;
                    default:
                        return false;

                }
            }
            await _unitOfWork.Orders.UpdateAsync(order);
                await _unitOfWork.CompleteAsync();
            return true;
        }


        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null) return false;

            order.Status = "deleted";

            var updated = await _unitOfWork.Orders.DeleteAsync(id);
            if (!updated) return false;

            await _unitOfWork.CompleteAsync();
            return true;
        }


        public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null) return false;
            order.Status = status;
            await _unitOfWork.Orders.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<int?> GetLastOrderIdAsync()
        {
            return await _unitOfWork.Orders.GetLastOrderIdAsync();
        }


        public async Task<bool> IsOrderCancelledAsync(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            return order?.Status == "Cancelled"; 
        }
    }
}

