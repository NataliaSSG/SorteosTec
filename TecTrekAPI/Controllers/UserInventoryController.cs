using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UserInventoryController : ControllerBase
	{
		private readonly UserInventoryService _userInventoryService;

		public UserInventoryController(UserInventoryService userInventoryService)
		{
			_userInventoryService = userInventoryService;
		}

		[HttpGet]
		public async Task<ActionResult<List<UserInventoryModel>>> GetAllInventories()
		{
			return await _userInventoryService.GetAllInventoriesAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserInventoryModel>> GetInventoryById(int id)
		{
			var inventory = await _userInventoryService.GetInventoryByIdAsync(id);
			if (inventory == null)
			{
				return NotFound();
			}
			return inventory;
		}

		[HttpPost]
		public async Task<ActionResult<UserInventoryModel>> CreateInventory(UserInventoryModel newInventory)
		{
			var inventory = await _userInventoryService.CreateInventoryAsync(newInventory);
			return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.id_inventory }, inventory);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateInventory(int id, UserInventoryModel updatedInventory)
		{
			if (id != updatedInventory.id_inventory)
			{
				return BadRequest();
			}
			await _userInventoryService.UpdateInventoryAsync(updatedInventory);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteInventory(int id)
		{
			await _userInventoryService.DeleteInventoryAsync(id);
			return NoContent();
		}
	}
}