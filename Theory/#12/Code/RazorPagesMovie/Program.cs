//Scaffold generated
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
//Scaffold generated




////https error
///1.Close all browser instances
///2.run
///dotnet dev-certs https --trust




//Creates the DI container
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
////https error
///1.Close all browser instances
///2.run
///dotnet dev-certs https --trust



//Scaffold generated
//Creates the DI container
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>




////https error
///1.Close all browser instances
///2.run
///dotnet dev-certs https --trust



//Scaffold generated dbContext
//Creates the DI container
options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));


//Method .Build returns object of type WebApplication
var app = builder.Build();

//Seed initial data
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//Switch on http to https redirection
app.UseHttpsRedirection();

//Switch on static files support like .html, .js, .css, .img, etc.
app.UseStaticFiles();


//Routing mechanism
app.UseRouting();


//Auth support
app.UseAuthorization();


//Include Razor Pages support
app.MapRazorPages();


//Run the App
app.Run();
