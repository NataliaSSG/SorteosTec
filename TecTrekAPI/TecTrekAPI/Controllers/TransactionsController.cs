using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private readonly TransactionsService _transactionsService;

		public TransactionsController(TransactionsService transactionsService)
		{
			_transactionsService = transactionsService;
		}

		[HttpGet]
		public async Task<ActionResult<List<TransactionsModel>>> GetAllTransactions()
		{
			return await _transactionsService.GetAllTransactionsAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TransactionsModel>> GetTransactionById(int id)
		{
			var transaction = await _transactionsService.GetTransactionByIdAsync(id);
			if (transaction == null)
			{
				return NotFound();
			}
			return transaction;
		}

		[HttpPost]
		public async Task<ActionResult<TransactionsModel>> CreateTransaction(TransactionsModel newTransaction)
		{
			var transaction = await _transactionsService.CreateTransactionAsync(newTransaction);
			return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.id_transaction }, transaction);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTransaction(int id, TransactionsModel updatedTransaction)
		{
			if (id != updatedTransaction.id_transaction)
			{
				return BadRequest();
			}
			await _transactionsService.UpdateTransactionAsync(updatedTransaction);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTransaction(int id)
		{
			await _transactionsService.DeleteTransactionAsync(id);
			return NoContent();
		}
	}
}