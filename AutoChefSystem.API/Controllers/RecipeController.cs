using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        #region Get All Recipes
        /// <summary>
        /// Get all recipes in the system
        /// </summary>
        /// <returns>A paginated list of recipes</returns>
        /// <response code="200">Returns paginated recipes</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No recipes found</response>
        /// <response code="500">Internal server error</response>
        /// 
        [HttpGet("all")]
        public async Task<IActionResult> GetAllRecipes([FromQuery] string? name, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
        
            try
            {
                var result = await _recipeService.GetAllRecipesAsync(name, page, pageSize);

                if (result is not null)
                {
                    return Ok(result);
                }

                return NotFound(new
                {
                    ErrorMessage = "No recipes found in the database."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching recipes.");
                return StatusCode(500, new { ErrorMessage = "An unexpected error occurred. Please try again later." });
            }
        }
        #endregion

        #region Update Recipe
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateRecipeByIdRequest updateRecipe)
        {
            try
            {
                var updatedRecipe = await _recipeService.UpdateAsync(updateRecipe);
                return Ok(updatedRecipe);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        #endregion

        #region Get Recipe By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound(new { message = $"Recipe with ID {id} not found." });
            }
            return Ok(recipe);
        }


        #endregion

        #region
        [HttpPost("create")]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequest createRecipeRequest)
        {

            var result = await _recipeService.CreateRecipeAsync(createRecipeRequest);
           
            if (result == null)
            {
                return NotFound(new { message = $"Error when create new recipe " });
            }
            return Ok(result);
        }



        #endregion
    }
}
