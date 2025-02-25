using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories;
using AutoChefSystem.Repositories.Interfaces;
using AutoChefSystem.Repositories.Repositories;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoChefSystemContext _context;

        private readonly ILogger _logger;

        public IRoleRepository Roles { get; private set; }

        public IUserRepository Users { get; private set; }

        public ILocationRepository Locations { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IRecipeRepository Recipes { get; private set; }

        public IRecipeStepRepository RecipeSteps { get; private set; }

        public IRobotRepository Robots { get; private set; }

        public IRobotOperationLogRepository RobotOperations { get; private set; }

        public IRobotTypeRepository RobotTypes { get; private set; }


        public UnitOfWork(
            AutoChefSystemContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;

            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);

            Roles = new RoleRepository(_context, _logger);

            Locations = new LocationRepository(_context, _logger);

            Orders = new OrderRepository(_context, _logger);

            Recipes = new RecipeRepository(_context, _logger);

            RecipeSteps = new RecipeStepRepository(_context, _logger);

            Robots = new RobotRepository(_context, _logger);    

            RobotOperations = new RobotOperationLogRepository(_context, _logger);

            RobotTypes = new RobotTypeRepository(_context, _logger);



        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
    }
}
