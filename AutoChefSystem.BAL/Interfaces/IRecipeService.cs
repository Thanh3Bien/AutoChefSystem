
using AutoChefSystem.DAL.Entities;
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
        Task<List<GetAllRecipeRequest>> GetAllAsync();
    }
}
