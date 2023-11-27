using System;
using System.ComponentModel.DataAnnotations;
namespace TecTrekAPI.Models
{
	public class LeaderboardModel
	{
        [Key]
		public string username {set; get; }
        public long points {set; get; }
	}
}

