using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AddressController : ControllerBase
	{
		private readonly AddressService _addressService;

		public AddressController(AddressService addressService)
		{
			_addressService = addressService;
		}

		[HttpGet]
		public async Task<ActionResult<List<AddressModel>>> GetAllAddresses()
		{
			return await _addressService.GetAllAddressesAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AddressModel>> GetAddressById(int id)
		{
			var address = await _addressService.GetAddressByIdAsync(id);
			if (address == null)
			{
				return NotFound();
			}
			return address;
		}

		[HttpPost]
		public async Task<ActionResult<AddressModel>> CreateAddress(AddressModel newAddress)
		{
			var address = await _addressService.CreateAddressAsync(newAddress);
			return CreatedAtAction(nameof(GetAddressById), new { id = address.id_address }, address);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAddress(int id, AddressModel updatedAddress)
		{
			if (id != updatedAddress.id_address)
			{
				return BadRequest();
			}
			await _addressService.UpdateAddressAsync(updatedAddress);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAddress(int id)
		{
			await _addressService.DeleteAddressAsync(id);
			return NoContent();
		}
	}
}