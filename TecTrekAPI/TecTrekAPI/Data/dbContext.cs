using System;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Controllers;
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
		public DbSet<ItemsModel> items { set; get; }
		public DbSet<LogInModel> log_user { set; get; }
	}
}
