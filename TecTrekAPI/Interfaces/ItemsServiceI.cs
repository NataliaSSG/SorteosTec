using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
    public interface ItemsServiceI
    {
        Task<List<ItemsModel>> GetAllItemsAsync();
        Task<ItemsModel> GetItemByIdAsync(int id);
        Task<ItemsModel> CreateItemAsync(ItemsModel newItem);
        Task UpdateItemAsync(ItemsModel updatedItem);
        Task DeleteItemAsync(int id);
    }
}