using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Order;
using AutoChefSystem.Services.Models.Recipe;
using AutoMapper;
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
    }
}
