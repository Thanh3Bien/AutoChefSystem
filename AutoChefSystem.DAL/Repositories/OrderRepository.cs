using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
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

        public async  Task<Order?> CreateAsync(Order order)
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

        public async Task<(List<Order>, int)> GetAllOdersAsync(string? status, int page, int pageSize)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                // Filter by name
                if (!string.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(r => r.Status.Contains(status));
                }

                // Get total count for pagination
                var totalCount = await query.CountAsync();

                // Pagination
                var recipes = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (recipes, totalCount);
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
    }
    }

