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
    public class RobotTypeRepository : GenericRepository<RobotType>, IRobotTypeRepository
    {
        public RobotTypeRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<RobotType>> GetAllRobotTypesAsync(int pageNumber, int pageSize)
        {
            return await _context.RobotTypes
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<RobotType?> GetByIdAsync(int id)
        {
            return await _context.RobotTypes.FirstOrDefaultAsync(rt => rt.RobotTypeId == id);
        }

        public async Task AddRobotTypeAsync(RobotType robotType)
        {
            await _context.RobotTypes.AddAsync(robotType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRobotTypeAsync(RobotType robotType)
        {
            _context.RobotTypes.Update(robotType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRobotTypeAsync(int id)
        {
            var robotType = await _context.RobotTypes.FindAsync(id);
            if (robotType != null)
            {
                _context.RobotTypes.Remove(robotType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
