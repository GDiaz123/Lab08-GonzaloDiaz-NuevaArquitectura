using Microsoft.EntityFrameworkCore;

using Lab08_GonzaloDiaz.Features.Clientes;
using Lab08_GonzaloDiaz.Features.Order;
using Lab08_GonzaloDiaz.Features.OrderDetail;


using Lab08_GonzaloDiaz.Models;
using Lab08_GonzaloDiaz.Repositories;
using Lab08_GonzaloDiaz.Repository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(
    typeof(IGenericRepository<>),
    typeof(GenericRepository<>));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<IOrderServices, OrderService>();
builder.Services.AddScoped<IOrderDetailServices, OrderDetailService>();

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();