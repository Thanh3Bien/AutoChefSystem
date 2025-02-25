
using AutoChefSystem.Services.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<PaginatedRecipeResponse> GetAllRecipesAsync(string? name, int page, int pageSize);

        Task<UpdateRecipeByIdRequest> UpdateAsync(UpdateRecipeByIdRequest updateRecipe);

        Task<GetRecipeByIdResponse?> GetByIdAsync(int id);

        Task<CreateRecipeRequest?> CreateRecipeAsync(CreateRecipeRequest createRecipe);

    }
}
