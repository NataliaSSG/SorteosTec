using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Data;
using TecTrekAPI.Models;
using Microsoft.OpenApi.Services;
using TecTrekAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<dbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("dbContext"), 
    new MySqlServerVersion(new Version(8, 1, 0)))); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyecciones de las capas de servicios
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<ItemsService>();
builder.Services.AddScoped<LogInService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

