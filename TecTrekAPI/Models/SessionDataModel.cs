using System;
using System.Security.Cryptography.X509Certificates;
namespace TecTrekAPI.Models
{
	public class SessionDataModel
	{
		public string Username { get; set; }
		public string Role { get; set; }
		public int UserId { get; set; }
		public SessionDataModel()
		{
			
		}
	}
}

