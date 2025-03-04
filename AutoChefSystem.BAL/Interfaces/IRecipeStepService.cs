using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Services.Models.RecipeSteps;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRecipeStepService
    {
        Task<List<GetByRecipeIdRequest>> GetByRecipeIdAsync(int recipeId);

        Task<CreateRecipeStepRequest?> CreateRecipeStepAsync(CreateRecipeStepRequest createRecipeStep);

        Task<UpdateRecipeStepRequest?> UpdateRecipeStepAsync(UpdateRecipeStepRequest updateRecipeStep);
        Task DeleteRecipeStepAsync(int id);
    }
}
