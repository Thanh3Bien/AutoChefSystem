using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

        public async Task<Order?> CreateAsync(Order order)
        {
            try
            {
                await _dbSet.AddAsync(order);
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating new order .");
                throw;
            }
        }

        public async Task<bool> UpdateOrderStatusAsync(Order order)
        {
            try
            {
                _dbSet.Update(order);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating status for order with ID {order?.OrderId}.");
                return false;
            }
        }


        public async Task<(List<Order>, int)> GetAllOdersAsync(bool sort, string? status, int page, int pageSize)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                
                query = query.Where(r => r.Status != "deleted");

                if (!string.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(r => r.Status.Contains(status));
                }

                query = sort
                    ? query.OrderByDescending(r => r.OrderedTime)
                    : query.OrderBy(r => r.OrderedTime);

                var totalCount = await query.CountAsync();

                var orders = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (orders, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching orders.");
                throw;
            }
        }



        public async Task UpdateAsync(Order updateOrder)
        {
            try
            {
                _dbSet.Update(updateOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the order.");
                throw;
            }
        }

        public async Task<int?> GetLastOrderIdAsync()
        {
            try
            {
                var lastOrder = await _dbSet
                    .OrderByDescending(o => o.OrderedTime) 
                    .FirstOrDefaultAsync(); 

                return lastOrder?.OrderId; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching the last order ID.");
                throw;
            }
        }

        public async Task<List<Order>> GetOrdersSortedByTimeAsync(bool descending)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                query = descending
                    ? query.OrderByDescending(o => o.OrderedTime)
                    : query.OrderBy(o => o.OrderedTime);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching and sorting orders by OrderedTime.");
                throw;
            }
        }

        public async Task<Dictionary<string, int>> GetRecipeOrderCountAsync()
        {
            try
            {
                var recipeCounts = await _dbSet
                    .Include(o => o.Recipe) 
                    .GroupBy(o => o.Recipe.RecipeName) 
                    .Select(g => new { RecipeName = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.RecipeName, x => x.Count);

                return recipeCounts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching order count per RecipeName.");
                throw;
            }
        }

        public async Task<double?> GetAverageCompletionTimeAsync()
        {
            try
            {
                var avgTime = await _dbSet
     .Where(o => o.CompletedTime != null)
     .AverageAsync(o => EF.Functions.DateDiffSecond(
         (DateTime)o.OrderedTime,
         (DateTime)o.CompletedTime
     ));


                return avgTime;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while calculating average order completion time.");
                throw;
            }
        }

    }
}


