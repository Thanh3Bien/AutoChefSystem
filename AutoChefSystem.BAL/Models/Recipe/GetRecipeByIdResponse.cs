using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Recipe
{
    public class GetRecipeByIdResponse
    {
        public int RecipeId { get; set; }

        public string RecipeName { get; set; } = null!;

        public string Ingredients { get; set; } = null!;
    }
}
