using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Services.Models.RecipeSteps;
using AutoChefSystem.Services.Models.RobotStepTask;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IRecipeStepService
    {
        Task<PaginatedRecipeStepResponse> GetAllAsync(int pageNumber, int pageSize);
        Task<List<GetByRecipeIdRequest>> GetByRecipeIdAsync(int recipeId);

        Task<CreateRecipeStepRequest?> CreateRecipeStepAsync(CreateRecipeStepRequest createRecipeStep);

        Task<UpdateRecipeStepRequest?> UpdateRecipeStepAsync(UpdateRecipeStepRequest updateRecipeStep);
        Task DeleteRecipeStepAsync(int id);
    }
}
