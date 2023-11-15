using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
	public interface TransactionServiceI
	{
		Task<List<TransactionsModel>> GetAllTransactionsAsync();
		Task<TransactionsModel> GetTransactionByIdAsync(int id);
		Task<TransactionsModel> CreateTransactionAsync(TransactionsModel newTransaction);
		Task UpdateTransactionAsync(TransactionsModel updatedTransaction);
		Task DeleteTransactionAsync(int id);
	}
}