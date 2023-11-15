using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Data;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{
	public class ItemsService : ItemsServiceI
	{
		private readonly dbContext _context;

		public ItemsService(dbContext context)
		{
			_context = context;
		}

		public async Task<List<ItemsModel>> GetAllItemsAsync()
		{
			return await _context.items.ToListAsync();
		}

		public async Task<ItemsModel> GetItemByIdAsync(int id)
		{
			return await _context.items.FindAsync(id);
		}

		public async Task<ItemsModel> CreateItemAsync(ItemsModel newItem)
		{
			_context.items.Add(newItem);
			await _context.SaveChangesAsync();
			return newItem;
		}

		public async Task UpdateItemAsync(ItemsModel updatedItem)
		{
			_context.Entry(updatedItem).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteItemAsync(int id)
		{
			var item = await _context.items.FindAsync(id);
			_context.items.Remove(item);
			await _context.SaveChangesAsync();
		}
	}
}
