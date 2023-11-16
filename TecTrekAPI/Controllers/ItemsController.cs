using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private readonly ItemsService _itemsService;

		public ItemsController(ItemsService itemsService)
		{
			_itemsService = itemsService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ItemsModel>>> GetAllItems()
		{
			return await _itemsService.GetAllItemsAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ItemsModel>> GetItemById(int id)
		{
			var item = await _itemsService.GetItemByIdAsync(id);
			if (item == null)
			{
				return NotFound();
			}
			return item;
		}

		[HttpPost]
		public async Task<ActionResult<ItemsModel>> CreateItem(ItemsModel newItem)
		{
			var item = await _itemsService.CreateItemAsync(newItem);
			return CreatedAtAction(nameof(GetItemById), new { id = item.id_item }, item);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateItem(int id, ItemsModel updatedItem)
		{
			if (id != updatedItem.id_item)
			{
				return BadRequest();
			}
			await _itemsService.UpdateItemAsync(updatedItem);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteItem(int id)
		{
			await _itemsService.DeleteItemAsync(id);
			return NoContent();
		}
	}
}