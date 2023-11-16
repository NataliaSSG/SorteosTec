using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
	public interface AddOnsServiceI
	{
		Task<List<AddOnsModel>> GetAllAddOnsAsync();
		Task<AddOnsModel> GetAddOnByIdAsync(int id);
		Task<AddOnsModel> CreateAddOnAsync(AddOnsModel newAddOn);
		Task UpdateAddOnAsync(AddOnsModel updatedAddOn);
		Task DeleteAddOnAsync(int id);
	}
}