using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories.Entities;
namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRecipeStepRepository
    {
        Task<List<RecipeStep>> GetAllAsync(int pageNumber, int pageSize);
        public Task<List<RecipeStep>> GetByRecipeIdAsync(int recipeId);
        Task<RecipeStep?> CreateAsync(RecipeStep recipeStep);

        Task<RecipeStep?> UpdateAsync(RecipeStep recipeStep);

        Task<bool> DeleteAsync(int id);
    }
}
