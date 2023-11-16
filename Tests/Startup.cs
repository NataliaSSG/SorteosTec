using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Services;
using TecTrekAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
	public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddControllers();

			// Add any custom services.
			services.AddTransient<AddOnsServiceI, AddOnsService>();
			services.AddTransient<AddressServiceI, AddressService>();
			services.AddTransient<IClienteService, ClienteService>();
			services.AddTransient<ItemsServiceI, ItemsService>();
			services.AddTransient<ILogInService, LogInService>();
			services.AddTransient<TransactionServiceI, TransactionsService>();
			services.AddTransient<UserInventoryServiceI, UserInventoryService>();

			// Add DbContext
			services.AddDbContext<dbContext>(options =>
				options.UseInMemoryDatabase(databaseName: "TestDB"));

		}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

