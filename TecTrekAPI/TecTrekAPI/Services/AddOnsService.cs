using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Data;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{
	public class AddOnsService
	{
		private readonly dbContext _context;

		public AddOnsService(dbContext context)
		{
			_context = context;
		}

		public async Task<List<AddOnsModel>> GetAllAddOnsAsync()
		{
			return await _context.add_ons.ToListAsync();
		}

		public async Task<AddOnsModel> GetAddOnByIdAsync(int id)
		{
			return await _context.add_ons.FindAsync(id);
		}

		public async Task<AddOnsModel> CreateAddOnAsync(AddOnsModel newAddOn)
		{
			_context.add_ons.Add(newAddOn);
			await _context.SaveChangesAsync();
			return newAddOn;
		}

		public async Task UpdateAddOnAsync(AddOnsModel updatedAddOn)
		{
			_context.Entry(updatedAddOn).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAddOnAsync(int id)
		{
			var addOn = await _context.add_ons.FindAsync(id);
			_context.add_ons.Remove(addOn);
			await _context.SaveChangesAsync();
		}
	}
}