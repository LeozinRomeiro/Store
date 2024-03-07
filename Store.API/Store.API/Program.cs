using Store.Domain.Repositories.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Services.Interfaces;
using Store.Domain.Services;
using Microsoft.Data.SqlClient;
using Store.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();
builder.Services.AddScoped(x => new SqlConnection("connectionString"));
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IDiscountRepository, DiscountRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
