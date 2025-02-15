using AutoChefSystem.BAL.Interfaces;
using AutoChefSystem.BAL.Models.Noodle;
using AutoChefSystem.BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	/*[Authorize]*/
	public class NoodlesController : ControllerBase
	{
		private readonly INoodleService _noodleService;

		public NoodlesController(INoodleService noodleService)
		{
			_noodleService = noodleService;
		}

		[HttpGet]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			try
			{
				var result = await _noodleService.GetByIdAsync(id);
				if (result is not null)
				{
					return Ok(result);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return NotFound(new { ErrorMessage = "No noodle found" });
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(CreateNoodleRequest createNoodleRequest)
		{
			try
			{
				var result = await _noodleService.AddAsync(createNoodleRequest);
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
		public async Task<IActionResult> UpdateAsync(UpdateNoodleRequest updateNoodleRequest)
		{
			try
			{
				var result = await _noodleService.UpdateAsync(updateNoodleRequest);
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
				await _noodleService.DeleteAsync(id);
				return Ok();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}