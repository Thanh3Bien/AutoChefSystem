using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RecipeSteps;
using AutoMapper;

namespace AutoChefSystem.Services.Services
{
    public class RecipeStepService : IRecipeStepService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RecipeStepService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateRecipeStepRequest?> CreateRecipeStepAsync(CreateRecipeStepRequest createRecipeStep)
        {
            var recipeStep = _mapper.Map<RecipeStep>(createRecipeStep);
            var createdRecipeStep = await _unitOfWork.RecipeSteps.CreateAsync(recipeStep);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CreateRecipeStepRequest>(createRecipeStep);
        }

        public async Task DeleteRecipeStepAsync(int id) => await _unitOfWork.RecipeSteps.DeleteAsync(id);

        public async Task<List<GetByRecipeIdRequest>> GetByRecipeIdAsync(int recipeId) => _mapper.Map<List<GetByRecipeIdRequest>> (await _unitOfWork.RecipeSteps.GetByRecipeIdAsync(recipeId));

        public async Task<UpdateRecipeStepRequest?> UpdateRecipeStepAsync(UpdateRecipeStepRequest updateRecipeStep)
        {
            var recipeStep = _mapper.Map<RecipeStep>(updateRecipeStep);
            await _unitOfWork.RecipeSteps.UpdateAsync(recipeStep);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<UpdateRecipeStepRequest>(updateRecipeStep);
        }
    }
}
