using System;
using System.ComponentModel.DataAnnotations;

namespace TecTrekAPI.Models
{
	public class ClienteModel
	{
		[Key]
		public int id_client { set; get; }
		public String first_name { set; get; }
		public String last_name { set; get; }
		public DateTime birth_date { set; get; }
		public int sexo { set; get; }
		public String email { set; get; }
		public String username { set; get; }
		public string? role { set; get; }
		public String user_password { set; get; }
		public int points { set; get; }

		public ClienteModel()
		{

		}
	}
}

