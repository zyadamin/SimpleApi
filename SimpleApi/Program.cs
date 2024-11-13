using Microsoft.EntityFrameworkCore;
using SimpleApi.BLL.Service;
using SimpleApi.BLL.Service.Intrfaces;
using SimpleApi.DAL.Context;
using SimpleApi.DAL.Repositories;
using SimpleApi.DAL.UnitOfWorks;
using SimpleApi.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));


builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>) );
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IOrderService,OrderService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(op=>op.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
