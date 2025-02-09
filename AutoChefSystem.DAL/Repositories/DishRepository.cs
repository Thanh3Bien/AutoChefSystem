using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.DAL.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        public DishRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

    }
}
