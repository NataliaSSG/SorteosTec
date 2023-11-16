using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TecTrekAPI.Models
{
	public class UserInventoryModel
	{
		[Key]
		public int id_inventory { get; set; }
		public int id_client { get; set; }
		[ForeignKey("id_client")]
		public ClienteModel client { get; set; }
		public int id_item { get; set; }
		[ForeignKey("id_item")]
		public ItemsModel item { get; set; }
		public int quantity { get; set; }
	}
}

