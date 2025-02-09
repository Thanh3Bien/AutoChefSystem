using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.DAL.Infrastructures
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
    }
}
