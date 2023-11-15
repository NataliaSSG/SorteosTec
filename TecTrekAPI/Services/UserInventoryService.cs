using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Data;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{
	public class UserInventoryService : UserInventoryServiceI
	{
		private readonly dbContext _context;

		public UserInventoryService(dbContext context)
		{
			_context = context;
		}

		public async Task<List<UserInventoryModel>> GetAllInventoriesAsync()
		{
			return await _context.user_inventory.ToListAsync();
		}

		public async Task<UserInventoryModel> GetInventoryByIdAsync(int id)
		{
			return await _context.user_inventory.FindAsync(id);
		}

		public async Task<UserInventoryModel> CreateInventoryAsync(UserInventoryModel newInventory)
		{
			_context.user_inventory.Add(newInventory);
			await _context.SaveChangesAsync();
			return newInventory;
		}

		public async Task UpdateInventoryAsync(UserInventoryModel updatedInventory)
		{
			_context.Entry(updatedInventory).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteInventoryAsync(int id)
		{
			var inventory = await _context.user_inventory.FindAsync(id);
			_context.user_inventory.Remove(inventory);
			await _context.SaveChangesAsync();
		}
	}
}