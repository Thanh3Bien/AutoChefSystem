using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<GetByRecipeIdRequest>> GetByRecipeIdAsync(int recipeId) => _mapper.Map<List<GetByRecipeIdRequest>> (await _unitOfWork.RecipeSteps.GetByRecipeIdAsync(recipeId));
    }
}
