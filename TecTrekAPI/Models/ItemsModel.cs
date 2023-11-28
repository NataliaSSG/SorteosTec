using System;
using System.ComponentModel.DataAnnotations;
namespace TecTrekAPI.Models
{
	public class ItemsModel
	{
		[Key]
		public int id_item { get; set; }
		public string item_name { get; set; }
		public int item_virtual_price { get; set; }
		public float item_real_price { get; set; }
		public string? description { get; set; }
	
	}
}

