using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Interfaces;

namespace AutoChefSystem.DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        IBrothRepository Broths { get; }

        ICustomerRepository Customers { get; }

        IDishRepository Dishs { get; }

        IFeedbackRepository Feedbacks { get; }

        IIngredientRepository Ingredients { get; }

        INoodleRepository Noodles { get; }

        //IOrderDetailRepository OrderDetails { get; }

        IOrderRepository Orders { get; }

        IRoleRepository Roles { get; }

        IUserRepository Users { get; }

        Task CompleteAsync();



    }
}
