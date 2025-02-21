using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
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

        public async Task<List<GetAllRecipeRequest>> GetAllAsync()
        {
            var recipes = await _unitOfWork.Recipes.GetAllAsync();
            return _mapper.Map<List<GetAllRecipeRequest>>(recipes);
        }
    }

}
