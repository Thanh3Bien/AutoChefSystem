using AutoChefSystem.Services.Interfaces;
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

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            try
            {
                var recipes = await _recipeService.GetAllAsync();
                if (recipes is not null)
                {
                    return Ok(recipes);
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
    }
}
