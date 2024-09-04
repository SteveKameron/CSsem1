using RazorPagesSampleWebApp;
using RazorPagesSampleWebApp.Pages.Areas.Books;



var builder = WebApplication.CreateBuilder(args);

//������� ��� ���������� ��� ������ Razor Pages(������ ����������, ������ ������ � ��������� �������)
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
//CSS & JS, � ����� ������� HTML ��������
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//������������� �������� ����� ��� Razor Pages localhost/Admin/User
//�� ���������, �������� ��� ������� /Hello ����� ����� ���� � Pages/Hello.cshtml
app.MapRazorPages();

app.Run();
