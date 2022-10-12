using HardwareStore.Infrastructure.Data;
using HardwareStore.Infrastructure.Repositories;
using HardwareStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IProductRepositorie, ProductRepositorie>();
builder.Services.AddTransient<IBrandsRepositorie, BrandRepositorie>();
builder.Services.AddTransient<ISupplierRepositorie, SupplierRepositorie>();
builder.Services.AddTransient<IHardwareCategoryRepositorie, HardwareCategoryRepositorie>();
builder.Services.AddTransient<IPurchaseRepositorie, PurchaseRepositorie>();
builder.Services.AddTransient<IStockProducts, StockRepositorie>();

builder.Services.AddDbContext<HardwareHubContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HardwareHubDB") ??
                            throw new InvalidOperationException("Connectionstring 'HardwareHub' not found.")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
