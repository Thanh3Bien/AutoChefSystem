using AutoChefSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> CreateAsync(Order order);

        Task UpdateAsync(Order updateOrder);

        Task<Order?> GetByIdAsync(int id);
        Task<(List<Order>, int)> GetAllOdersAsync(string? status, int page, int pageSize);


    }
}
