using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TecTrekAPI.Models;
using TecTrekAPI.Data;

namespace TecTrekAPI.Tests
{
	public class dbContextTests
	{
		[Fact]
		public async Task CanInsertIntoDatabase()
		{
			var options = new DbContextOptionsBuilder<dbContext>()
				.UseInMemoryDatabase(databaseName: "TestDB")
				.Options;

			using (var context = new dbContext(options))
			{
				var testClient = new ClienteModel { id_client = 1, 
													first_name = "Test", 
													last_name = "Client", 
													birth_date = new System.DateTime(2021, 1, 1), 
													sexo = 1, 
													email = "test@mail.com", 
													admin = false, 
													user_password = "123456",
													username = "testUser" 
												};

				context.client.Add(testClient);
				await context.SaveChangesAsync();

				var clientFromDb = context.client.FirstOrDefault(c => c.id_client == testClient.id_client);
				Assert.NotNull(clientFromDb);
				// Assert other properties here
			}
		}

		// Add other tests here
	}
}