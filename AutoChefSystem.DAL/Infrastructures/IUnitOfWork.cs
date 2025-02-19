using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Interfaces;
using AutoChefSystem.Repositories.Interfaces;

namespace AutoChefSystem.DAL.Infrastructures
{
    public interface IUnitOfWork
    {

        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        ILocationRepository Locations { get; }
        IOrderRepository Orders { get; }
        IRecipeRepository Recipes { get; }
        IRecipeStepRepository RecipeSteps { get; }
        IRobotRepository Robots { get; }    
        IRobotOperationLogRepository RobotOperations { get; }
        IRobotTaskRepository RobotTasks { get; }
        IRobotTypeRepository RobotTypes { get; }
        IStepTaskRepository StepTasks { get; }

        Task CompleteAsync();



    }
}
