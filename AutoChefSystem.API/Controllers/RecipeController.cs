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
        /// Get all recipes in the system with optional filtering and pagination.
        /// </summary>
        /// <param name="name">Filter recipes by name (optional)</param>
        /// <param name="page">Current page number (default is 1)</param>
        /// <param name="pageSize">Number of recipes per page (default is 10)</param>
        /// <returns>A paginated list of recipes</returns>
        /// <response code="200">Returns paginated recipes</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No recipes found</response>
        /// <response code="500">Internal server error</response>
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
                return NotFound(new { ErrorMessage = "No recipes found in the database." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching recipes.");
                return StatusCode(500, new { ErrorMessage = "An unexpected error occurred. Please try again later." });
            }
        }
        #endregion

        #region Update Recipe
        /// <summary>
        /// Update an existing recipe by ID.
        /// </summary>
        /// <param name="updateRecipe">The updated recipe details</param>
        /// <returns>The updated recipe</returns>
        /// <response code="200">Recipe updated successfully</response>
        /// <response code="404">Recipe not found</response>
        /// <response code="500">Internal server error</response>
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
        /// <summary>
        /// Get a recipe by its ID.
        /// </summary>
        /// <param name="id">The ID of the recipe</param>
        /// <returns>The recipe details</returns>
        /// <response code="200">Recipe found</response>
        /// <response code="404">Recipe not found</response>
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

        #region Create Recipe
        /// <summary>
        /// Create a new recipe.
        /// </summary>
        /// <param name="createRecipeRequest">The recipe details to create</param>
        /// <returns>The created recipe</returns>
        /// <response code="200">Recipe created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequest createRecipeRequest)
        {
            var result = await _recipeService.CreateRecipeAsync(createRecipeRequest);
            if (result == null)
            {
                return NotFound(new { message = "Error when creating new recipe." });
            }
            return Ok(result);
        }
        #endregion

        #region Delete Recipe
        /// <summary>
        /// Delete a recipe by its ID.
        /// </summary>
        /// <param name="id">The ID of the recipe</param>
        /// <returns>No content if the recipe was deleted</returns>
        /// <response code="204">Recipe deleted successfully</response>
        /// <response code="404">Recipe not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            try
            {
                var result =  await _recipeService.GetByIdAsync(id); 
                if (result == null)
                {
                    return NotFound(new { message = $"Recipe with ID {id} not found." });
                }
                await _recipeService.DeleteRecipeAsync(id);
                return Ok(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
