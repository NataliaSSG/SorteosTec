using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Controllers;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
	public interface ILogInService
	{
		Task<List<LogInModel>> GetAllLogInsAsync();
		Task<LogInModel> GetLogInByIdAsync(int id);
		Task<LogInModel> CreateLogInAsync(LogInModel newLogIn);
		Task UpdateLogInAsync(LogInModel updatedLogIn);
		Task DeleteLogInAsync(int id);
	}
}