using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.DAL.Repositories;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Repositories
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }

        public async Task<Recipe> CreateAsync(Recipe recipe)
        {
            try
            {
                await _dbSet.AddAsync(recipe);
                await _context.SaveChangesAsync();
                return recipe;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a recipe.");
                throw;
            }
        }


        public async Task<(List<Recipe>, int)> GetAllRecipesAsync(string? name, int page, int pageSize)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                // Filter by name
                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(r => r.RecipeName.Contains(name));
                }

                // Get total count for pagination
                var totalCount = await query.CountAsync();

                // Pagination
                var recipes = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (recipes, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching recipes.");
                throw;
            }
        }


        public async Task UpdateAsync(Recipe updateRecipe)
        {
            try
            {
                _dbSet.Update(updateRecipe);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the recipe.");
                throw;
            }
        }

    }
}
