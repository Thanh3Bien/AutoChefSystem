using AutoChefSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<(List<Recipe>, int)> GetAllRecipesAsync(string? name, int page, int pageSize);

        Task UpdateAsync(Recipe updateRecipe);

        Task<Recipe?> GetByIdAsync(int id);

    }
}
