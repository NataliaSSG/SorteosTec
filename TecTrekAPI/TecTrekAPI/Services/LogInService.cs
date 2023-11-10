using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Controllers;
using TecTrekAPI.Data;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{
	public class LogInService
	{
		private readonly dbContext _context;

		public LogInService(dbContext context)
		{
			_context = context;
		}

		public async Task<List<LogInModel>> GetAllLogInsAsync()
		{
			return await _context.log_user.ToListAsync();
		}

		public async Task<LogInModel> GetLogInByIdAsync(int id)
		{
			return await _context.log_user.FindAsync(id);
		}

		public async Task<LogInModel> CreateLogInAsync(LogInModel newLogIn)
		{
			_context.log_user.Add(newLogIn);
			await _context.SaveChangesAsync();
			return newLogIn;
		}

		public async Task UpdateLogInAsync(LogInModel updatedLogIn)
		{
			_context.Entry(updatedLogIn).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteLogInAsync(int id)
		{
			var logIn = await _context.log_user.FindAsync(id);
			_context.log_user.Remove(logIn);
			await _context.SaveChangesAsync();
		}
	}
}