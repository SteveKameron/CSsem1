using ChatServer.Hubs;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");
app.MapHub<GroupChatHub>("/groupchat");

app.Map("/", async (HttpContext context) =>
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append("<h1>SignalR Sample</h1>");
        stringBuilder.Append("<div>Open <a href='/ChatWindow.html'>ChatWindow</a> for communication</div>");
        await context.Response.WriteAsync(stringBuilder.ToString());
    });

app.UseStaticFiles();

//app.UseEndpoints(endpoints =>
//{

//});

// Configure the HTTP request pipeline.


//app.UseHttpsRedirection();


//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

app.Run();
