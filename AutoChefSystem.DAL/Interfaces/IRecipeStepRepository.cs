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
        public Task<List<RecipeStep>> GetByRecipeIdAsync(int recipeId);
    }
}
