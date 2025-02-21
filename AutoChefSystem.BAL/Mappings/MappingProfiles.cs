using AutoChefSystem.DAL.Entities;
using AutoChefSystem.Services.Models.Recipe;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Recipe
            CreateMap<Recipe, GetAllRecipeRequest>();
            CreateMap<GetAllRecipeRequest, Recipe>();
            #endregion
        }
    }
}
