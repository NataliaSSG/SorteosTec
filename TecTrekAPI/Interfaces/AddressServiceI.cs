using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
	public interface AddressServiceI
	{
		Task<List<AddressModel>> GetAllAddressesAsync();
		Task<AddressModel> GetAddressByIdAsync(int id);
		Task<AddressModel> CreateAddressAsync(AddressModel newAddress);
		Task UpdateAddressAsync(AddressModel updatedAddress);
		Task DeleteAddressAsync(int id);
	}
}