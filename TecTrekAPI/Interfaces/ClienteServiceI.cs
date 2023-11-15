using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
	public interface IClienteService
	{
		Task<List<ClienteModel>> GetAllClientesAsync();
		Task<ClienteModel?> GetClienteByIdAsync(int id);
		Task<ClienteModel> CreateClienteAsync(ClienteModel cliente);
		Task UpdateClienteAsync(ClienteModel cliente);
		Task DeleteClienteAsync(int id);
	}
}