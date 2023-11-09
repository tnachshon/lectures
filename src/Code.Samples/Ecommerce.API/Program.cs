using Ecommerce.API.EF;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
		options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();

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
