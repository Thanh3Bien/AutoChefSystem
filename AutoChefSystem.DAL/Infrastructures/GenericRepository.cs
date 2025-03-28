﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Infrastructures
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected AutoChefSystemContext _context;
        protected DbSet<TEntity> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(
            AutoChefSystemContext context,
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual TEntity AddEntity(TEntity entity) => _dbSet.Add(entity).Entity;

        public void UpdateEntity(TEntity entity) => _context.Update(entity).State = EntityState.Modified;

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"Entity with id {id} not found.");
                return false;
            }

            var statusProperty = entity.GetType().GetProperty("Status");
            if (statusProperty != null && statusProperty.PropertyType == typeof(string))
            {
                statusProperty.SetValue(entity, "deleted");
                _context.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity); 
            }

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
