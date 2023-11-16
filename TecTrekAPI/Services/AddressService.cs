using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Data;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{
	public class AddressService : AddressServiceI
	{
		private readonly dbContext _context;

		public AddressService(dbContext context)
		{
			_context = context;
		}

		public async Task<List<AddressModel>> GetAllAddressesAsync()
		{
			return await _context.address.ToListAsync();
		}

		public async Task<AddressModel> GetAddressByIdAsync(int id)
		{
			return await _context.address.FindAsync(id);
		}

		public async Task<AddressModel> CreateAddressAsync(AddressModel newAddress)
		{
			_context.address.Add(newAddress);
			await _context.SaveChangesAsync();
			return newAddress;
		}

		public async Task UpdateAddressAsync(AddressModel updatedAddress)
		{
			_context.Entry(updatedAddress).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAddressAsync(int id)
		{
			var removeAddress = await _context.address.FindAsync(id);
			_context.address.Remove(removeAddress);
			await _context.SaveChangesAsync();
		}
	}
}