using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TecTrekAPI.Models
{
	public class AddressModel
	{
		[Key]
		public int id_address { set; get; }
		public int id_client { set; get; }
		
		// [ForeignKey("id_client")]
		// public ClienteModel id_cliente { set; get; }

		public string state_name { set; get; }
		public string city_name { set; get; }

	}
}

