using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TecTrekAPI.Models
{
	public class TransactionsModel
	{
		[Key]
		public int id_transaction { get; set; }
		public int id_client { get; set; }
		[ForeignKey("id_client")]
		public ClienteModel client { get; set; }
		public int id_item { get; set; }
		[ForeignKey("id_item")]
		public ItemsModel item { get; set; }
		public int quantity { get; set; }
		public bool payment_type { get; set; }
		public DateTime transaction_date { get; set; }
	}
}

