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
    public class RobotRepository : GenericRepository<Robot>, IRobotRepository
    {
        public RobotRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

        public async Task<Robot?> GetByIdAsync(int id)
        {
            return await _context.Robots
                .Include(r => r.RobotType)
                .Include(r => r.Location)
                .FirstOrDefaultAsync(r => r.RobotId == id);
        }

        public async Task<IEnumerable<Robot>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Robots
                .Include(r => r.RobotType)
                .Include(r => r.Location)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Robots.CountAsync();
        }

        public async Task AddAsync(Robot robot)
        {
            await _context.Robots.AddAsync(robot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Robot robot)
        {
            _context.Robots.Update(robot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var robot = await _context.Robots.FindAsync(id);
            if (robot != null)
            {
                robot.IsActive = false;
                _context.Robots.Update(robot);
                await _context.SaveChangesAsync();
            }
        }
    }
}
