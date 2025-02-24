using AutoChefSystem.Services.Interfaces;
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

    }
}
