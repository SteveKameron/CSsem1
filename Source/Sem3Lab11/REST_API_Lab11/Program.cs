using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer("Server=localhost,1433;Database=Northwind;User Id=sa;Password=HelloWorld10;TrustServerCertificate=True;"));

builder.Services.AddControllers();
var app = builder.Build();



app.MapControllers();

app.Run();
