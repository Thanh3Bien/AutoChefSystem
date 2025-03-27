using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Repositories
{
    public class RobotStepTaskRepository : GenericRepository<RobotOperationLog>, IRobotStepTaskRepository
    {
        public RobotStepTaskRepository(
         AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

        public async Task<List<RobotStepTask>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.RobotStepTasks
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<RobotStepTask?> GetByIdAsync(int id)
        {
            return await _context.RobotStepTasks
                .FirstOrDefaultAsync(x => x.StepTaskId == id);
        }

        public async Task CreateAsync(RobotStepTask entity)
        {
            await _context.RobotStepTasks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RobotStepTask entity)
        {
            _context.RobotStepTasks.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RobotStepTasks.FirstOrDefaultAsync(x => x.StepTaskId == id);
            if (entity != null)
            {
                _context.RobotStepTasks.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
