using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Data;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{
	public class TransactionsService
	{
		private readonly dbContext _context;

		public TransactionsService(dbContext context)
		{
			_context = context;
		}

		public async Task<List<TransactionsModel>> GetAllTransactionsAsync()
		{
			return await _context.transactions.ToListAsync();
		}

		public async Task<TransactionsModel> GetTransactionByIdAsync(int id)
		{
			return await _context.transactions.FindAsync(id);
		}

		public async Task<TransactionsModel> CreateTransactionAsync(TransactionsModel newTransaction)
		{
			_context.transactions.Add(newTransaction);
			await _context.SaveChangesAsync();
			return newTransaction;
		}

		public async Task UpdateTransactionAsync(TransactionsModel updatedTransaction)
		{
			_context.Entry(updatedTransaction).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteTransactionAsync(int id)
		{
			var transaction = await _context.transactions.FindAsync(id);
			_context.transactions.Remove(transaction);
			await _context.SaveChangesAsync();
		}
	}
}