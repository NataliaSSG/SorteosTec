using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class LogInsController : ControllerBase
	{
		private readonly LogInService _logInService;

		public LogInsController(LogInService logInService)
		{
			_logInService = logInService;
		}

		[HttpGet]
		public async Task<ActionResult<List<LogInModel>>> GetAllLogIns()
		{
			return await _logInService.GetAllLogInsAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<LogInModel>> GetLogInById(int id)
		{
			var logIn = await _logInService.GetLogInByIdAsync(id);
			if (logIn == null)
			{
				return NotFound();
			}
			return logIn;
		}

		[HttpPost]
		public async Task<ActionResult<LogInModel>> CreateLogIn(LogInModel newLogIn)
		{
			var logIn = await _logInService.CreateLogInAsync(newLogIn);
			return CreatedAtAction(nameof(GetLogInById), new { id = logIn.id_log }, logIn);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateLogIn(int id, LogInModel updatedLogIn)
		{
			if (id != updatedLogIn.id_log)
			{
				return BadRequest();
			}
			await _logInService.UpdateLogInAsync(updatedLogIn);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLogIn(int id)
		{
			await _logInService.DeleteLogInAsync(id);
			return NoContent();
		}
	}
}