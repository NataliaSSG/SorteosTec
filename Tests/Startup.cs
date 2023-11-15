using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Services;

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

			// Add DbContext
			services.AddDbContext<dbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
                // Map controllers or other endpoints here.
                // For example, endpoints.MapControllers();
            });
        }
    }
}

