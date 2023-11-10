using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
namespace TecTrekAPI.Models
{
	public class AddOnsModel
	{
		[Key]
		public int id_add_on { get; set; }
		public int id_client { get; set; }
		[ForeignKey("id_client")]
		public ClienteModel client { get; set; }
		public int coins { get; set; }
		public int extra_lives { get; set; }
		public string current_skin { get; set; }
	}
}

