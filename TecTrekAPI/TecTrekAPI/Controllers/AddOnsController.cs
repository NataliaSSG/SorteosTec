using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AddOnsController : ControllerBase
	{
		private readonly AddOnsService _addOnsService;

		public AddOnsController(AddOnsService addOnsService)
		{
			_addOnsService = addOnsService;
		}

		[HttpGet]
		public async Task<ActionResult<List<AddOnsModel>>> GetAllAddOns()
		{
			return await _addOnsService.GetAllAddOnsAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AddOnsModel>> GetAddOnById(int id)
		{
			var addOn = await _addOnsService.GetAddOnByIdAsync(id);
			if (addOn == null)
			{
				return NotFound();
			}
			return addOn;
		}

		[HttpPost]
		public async Task<ActionResult<AddOnsModel>> CreateAddOn(AddOnsModel newAddOn)
		{
			var addOn = await _addOnsService.CreateAddOnAsync(newAddOn);
			return CreatedAtAction(nameof(GetAddOnById), new { id = addOn.id_add_on }, addOn);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAddOn(int id, AddOnsModel updatedAddOn)
		{
			if (id != updatedAddOn.id_add_on)
			{
				return BadRequest();
			}
			await _addOnsService.UpdateAddOnAsync(updatedAddOn);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAddOn(int id)
		{
			await _addOnsService.DeleteAddOnAsync(id);
			return NoContent();
		}
	}
}