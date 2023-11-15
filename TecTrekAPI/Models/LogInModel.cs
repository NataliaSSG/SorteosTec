using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using TecTrekAPI.Models;
namespace TecTrekAPI.Controllers
{
	public class LogInModel
	{
		[Key]
		public int id_log { get; set; }
		public int id_client { get; set; }

		[ForeignKey("id_client")]
		public ClienteModel client { get; set; }

		public DateTime log_in { get; set; }
		public DateTime log_out { get; set; }
		public int points { get; set; }
	}
}

