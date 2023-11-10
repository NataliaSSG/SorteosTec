using System;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Models;

namespace TecTrekAPI.Data
{
	public class dbContext : DbContext
	{
		public dbContext(DbContextOptions<dbContext> options) : base(options)
		{

		}

		public DbSet<ClienteModel> client { set; get; }
		public DbSet<AddressModel> address { set; get; }
	}
}
