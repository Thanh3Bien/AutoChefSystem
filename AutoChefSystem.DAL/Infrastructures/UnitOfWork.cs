using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Interfaces;
using AutoChefSystem.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.DAL.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoChefSystemContext _context;

        private readonly ILogger _logger;
        //public IBrothRepository Broths { get; private set; }

        //public ICustomerRepository Customers { get; private set; }

        //public IDishRepository Dishs { get; private set; }

        //public IFeedbackRepository Feedbacks { get; private set; }

        //public IIngredientRepository Ingredients { get; private set; }

        //public INoodleRepository Noodles { get; private set; }

        ////public IOrderDetailRepository OrderDetails { get; private set; }

        //public IOrderRepository Orders { get; private set; }

        public IRoleRepository Roles { get; private set; }

        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            AutoChefSystemContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;

            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);

            //Broths = new BrothRepository(_context, _logger);

            //Customers = new CustomerRepository(_context, _logger);

            //Dishs = new DishRepository(_context, _logger);

            //Feedbacks = new FeedbackRepository(_context, _logger);

            //Ingredients = new IngredientRepository(_context, _logger);

            //Noodles = new NoodleRepository(_context, _logger);

            ////OrderDetails = new OrderDetailRepository(_context, _logger);

            //Orders = new OrderRepository(_context, _logger);

            Roles = new RoleRepository(_context, _logger);
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
    }
}
