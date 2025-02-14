using AutoChefSystem.BAL.Interfaces;
using AutoChefSystem.BAL.Models.Broths;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	/*[Authorize]*/
	public class BrothsController : ControllerBase
	{
		private readonly IBrothService _brothService;
		public BrothsController(IBrothService brothService)
		{
			_brothService = brothService;
		}

		[HttpGet]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			try
			{
				var result = await _brothService.GetByIdAsync(id);
				if (result is not null)
				{
					return Ok(result);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return NotFound(new { ErrorMessage = "No broth found" });
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateBrothRequest createBrothRequest)
		{
			try
			{
				var result = await _brothService.AddAsync(createBrothRequest);
				if (result is not null)
				{
					return Ok(result);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return BadRequest();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync(UpdateBrothRequest updateBrothRequest)
		{
			try
			{
				var result = await _brothService.UpdateAsync(updateBrothRequest);
				if (result is not null)
				{
					return Ok(result);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return BadRequest();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			try
			{
				await _brothService.DeleteAsync(id);
				return Ok();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}