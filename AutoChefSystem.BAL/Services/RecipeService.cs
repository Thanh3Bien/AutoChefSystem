using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Recipe;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedRecipeResponse> GetAllRecipesAsync(string? name, int page, int pageSize)
        {
            var (recipes, totalCount) = await _unitOfWork.Recipes.GetAllRecipesAsync(name, page, pageSize);
            var recipeDtos = _mapper.Map<List<GetAllRecipeResponse>>(recipes);

            return new PaginatedRecipeResponse
            {
                Recipes = recipeDtos,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }


        public async Task<GetRecipeByIdResponse?> GetByIdAsync(int id)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);
            if (recipe == null)
            {
                return null; 
            }

            return _mapper.Map<GetRecipeByIdResponse>(recipe);
        }


        public async Task<UpdateRecipeByIdRequest> UpdateAsync(UpdateRecipeByIdRequest updateRecipe)
        {
            var existingRecipe = await _unitOfWork.Recipes.GetByIdAsync(updateRecipe.RecipeId);
            if (existingRecipe == null)
            {
                throw new KeyNotFoundException($"Recipe with ID {updateRecipe.RecipeId} not found.");
            }

            _mapper.Map(updateRecipe, existingRecipe); 
            await _unitOfWork.Recipes.UpdateAsync(existingRecipe);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UpdateRecipeByIdRequest>(existingRecipe); 
        }
        

        public async Task<CreateRecipeRequest?> CreateRecipeAsync(CreateRecipeRequest createRecipe)
        {
            var recipe = _mapper.Map<Recipe>(createRecipe);
            var createdRecipe = await _unitOfWork.Recipes.CreateAsync(recipe);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CreateRecipeRequest>(createRecipe);
        }
    }

}
