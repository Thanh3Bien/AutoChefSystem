using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Services.Models.RobotStepTask;

namespace AutoChefSystem.Services.Models.RecipeSteps
{
    public class PaginatedRecipeStepResponse
    {
        public List<RecipeStepResponse> Tasks { get; set; } = new();
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
