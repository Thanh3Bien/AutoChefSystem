using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RecipeSteps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/recipesteps")]
    [ApiController]
    public class RecipeStepController : ControllerBase
    {
        private readonly IRecipeStepService _recipeStepService;

        public RecipeStepController(IRecipeStepService recipeStepService)
        {
            _recipeStepService = recipeStepService;
        }
        #region Get All Recipe Steps
        /// <summary>
        /// Get all recipe steps with pagination.
        /// </summary>
        /// <param name="pageNumber">Current page number (default = 1)</param>
        /// <param name="pageSize">Number of tasks per page (default = 10)</param>
        /// <returns>A paginated list of recipe steps</returns>
        /// <response code="200">Returns a paginated list of steps</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _recipeStepService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }
        #endregion

        #region Get All RecipeStep by RecipeId
        /// <summary>
        /// Get List RecipeSteps based on RecipeId in the system
        /// </summary>
        /// <param name="recipeId">Id of Recipe you want to get RecipeSteps</param>
        /// <returns>A role</returns>
        /// <response code="200">Return list steps in the system</response>
        /// <response code="400">If the RecipeSteps is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("recipe/{recipeId}")]
        public async Task<IActionResult> GetByRecipeIdAsync(int recipeId)
        {
            var steps = await _recipeStepService.GetByRecipeIdAsync(recipeId);
            if (steps == null || steps.Count() == 0)
            {
                return NotFound(); 
            }

            return Ok(steps); 
        }
        #endregion

        #region Create Recipe Step
        /// <summary>
        /// Create a new recipe step.
        /// </summary>
        /// <param name="createRecipeStepRequest">The recipe step details to create</param>
        /// <returns>The created recipe step</returns>
        /// <response code="201">Recipe step created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateRecipeStep([FromBody] CreateRecipeStepRequest createRecipeStepRequest)
        {
            try
            {
                var result = await _recipeStepService.CreateRecipeStepAsync(createRecipeStepRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Recipe Step
        /// <summary>
        /// Update an existing recipe step.
        /// </summary>
        /// <param name="updateRecipeStepRequest">The updated recipe step details</param>
        /// <returns>The updated recipe step</returns>
        /// <response code="200">Recipe step updated successfully</response>
        /// <response code="404">Recipe step not found</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        public async Task<IActionResult> UpdateRecipeStep([FromBody] UpdateRecipeStepRequest updateRecipeStepRequest)
        {
            try
            {
                var result = await _recipeStepService.UpdateRecipeStepAsync(updateRecipeStepRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Delete Recipe Step
        /// <summary>
        /// Delete a recipe step by its ID.
        /// </summary>
        /// <param name="id">The ID of the recipe step</param>
        /// <returns>No content if the recipe step was deleted</returns>
        /// <response code="204">Recipe step deleted successfully</response>
        /// <response code="404">Recipe step not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeStep(int id)
        {
            try
            {
                await _recipeStepService.DeleteRecipeStepAsync(id);
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
