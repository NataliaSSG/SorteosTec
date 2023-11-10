using System;
namespace TecTrekAPI.Models
{
	public class ClienteModel
	{
		public int Id { set; get; }
		public String Nombre { set; get; }
		public String Apellido { set; get; }
		public DateTime FechaNacimiento { set; get; }
		public int Genero { set; get; }
		public String Correo { set; get; }
		public String Username { set; get; }

		public ClienteModel()
		{

		}
	}
}

