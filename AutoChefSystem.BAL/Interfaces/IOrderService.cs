using AutoChefSystem.Services.Models.Order;
using AutoChefSystem.Services.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderRequest> CreateOrderAsync(CreateOrderRequest createOrders);

        Task<UpdateOrderRequest> UpdateAsync(UpdateOrderRequest updateOrder);

        Task<GetOrderByIdResponse?> GetByIdAsync(int id);

        Task<PaginatedOrderResponse> GetAllOrdersAsync(bool sort, string? status, int page, int pageSize);
        Task<bool> UpdateOrderStatus(int orderId, bool isCancel);

        Task<bool> DeleteOrderAsync(int id);
    }
}
