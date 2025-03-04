using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RecipeSteps
{
    public class CreateRecipeStepRequest
    {

        public int RecipeId { get; set; }

        public string StepDescription { get; set; } = null!;

        public int StepNumber { get; set; }
    }
}
