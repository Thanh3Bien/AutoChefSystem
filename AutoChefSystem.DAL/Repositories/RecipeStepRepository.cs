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
    public class RecipeStepRepository : GenericRepository<RecipeStep>, IRecipeStepRepository
    {
        public RecipeStepRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }
        public async Task<List<RecipeStep>> GetByRecipeIdAsync(int recipeId)
        {
            var listRecipeSteps = new List<RecipeStep>();
            listRecipeSteps = await _context.RecipeSteps.Where(step => step.RecipeId == recipeId)
                                                        .OrderBy(step => step.StepNumber)
                                                        .ToListAsync();
            return listRecipeSteps;
        }


    }
}
