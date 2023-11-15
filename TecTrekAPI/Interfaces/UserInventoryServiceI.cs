using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
	public interface UserInventoryServiceI
	{
		Task<List<UserInventoryModel>> GetAllInventoriesAsync();
		Task<UserInventoryModel> GetInventoryByIdAsync(int id);
		Task<UserInventoryModel> CreateInventoryAsync(UserInventoryModel newInventory);
		Task UpdateInventoryAsync(UserInventoryModel updatedInventory);
		Task DeleteInventoryAsync(int id);
	}
}