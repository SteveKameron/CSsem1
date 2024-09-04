using RazorPagesSampleWebApp;
using RazorPagesSampleWebApp.Pages.Areas.Books;



var builder = WebApplication.CreateBuilder(args);

//добавим все необходимо для работы Razor Pages(движок рендеринга, службы поиска и активации страниц)
builder.Services.AddRazorPages();

builder.Services.AddSqlServer<CSharpBooksContext>("Data Source=localhost;Initial Catalog=CSharpBooks;User ID=sa;Password=HelloWorld10");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//CSS & JS, а также простые HTML страницы
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//Маршрутизация конечных точек для Razor Pages localhost/Admin/User
//По умолчанию, например для запроса /Hello поиск будет идти в Pages/Hello.cshtml
app.MapRazorPages();

app.Run();
