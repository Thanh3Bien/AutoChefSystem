using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
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

        public async Task<RecipeStep?> CreateAsync(RecipeStep recipeStep)
        {
            try
            {
                await _dbSet.AddAsync(recipeStep);
                await _context.SaveChangesAsync();
                return recipeStep;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a recipeStep.");
                throw;
            }
        }

        public async Task<List<RecipeStep>> GetByRecipeIdAsync(int recipeId)
        {
            var listRecipeSteps = new List<RecipeStep>();
            listRecipeSteps = await _context.RecipeSteps.Where(step => step.RecipeId == recipeId)
                                                        .OrderBy(step => step.StepNumber)
                                                        .ToListAsync();
            return listRecipeSteps;
        }

        public async Task<RecipeStep?> UpdateAsync(RecipeStep recipeStep)
        {
            try
            {
                var checkExistRecipeStep = await _dbSet.FindAsync(recipeStep.RecipeId);
                if (checkExistRecipeStep != null)
                {
                    checkExistRecipeStep.RecipeId = recipeStep.RecipeId;
                    checkExistRecipeStep.StepDescription = recipeStep.StepDescription;
                    checkExistRecipeStep.StepNumber = recipeStep.StepNumber;
                    _dbSet.Update(recipeStep);

                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return recipeStep;

        }
    }
}
