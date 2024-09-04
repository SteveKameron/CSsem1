 using global::Microsoft.AspNetCore.Builder;
 using global::Microsoft.AspNetCore.Hosting;
 using global::Microsoft.AspNetCore.Http;
 using global::Microsoft.AspNetCore.Routing;
 using global::Microsoft.Extensions.Configuration;
using System.Text;

using SampleWebApp.Extensions;
using SampleWebApp.Middleware;
using SampleWebApp.Services;

//�������������� ����� ��������� WebApplicationBuilder ������
//� �������������� ������������ ���������� �� ���������
var builder = WebApplication.CreateBuilder(args);

//��������� ��������� ��������
builder.Services.AddScoped<SessionSample>();

//��������� ������, ������ �������
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));

//RequestAndResponseSamples.cs
builder.Services.AddScoped<RequestAndResponseSamples>();


var app = builder.Build();

//����������� middleware
//IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
app.Use((context, next) =>
{
    context.Response.Headers.Add("CustomHeader1", "custom header value");
    return next(context);
});

//������� ����������� ������������ HTML-��������
app.UseStaticFiles();

//�������� ������
app.UseSession();

//����������� ����� UseStaticFiles, ������� �� ������������ � html - ����������
app.UseHeaderMiddleware();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/randr/{action?}", async context =>
    {
        var service = context.RequestServices.GetRequiredService<RequestAndResponseSamples>();
        //action ����� ���� null - ��� ������������ �������� � ������ ������
        string? action = context.GetRouteValue("action")?.ToString();
        //��� �������
        string method = context.Request.Method;
        //tuple ��������� � ����������� switch
        string result = (action, method) switch
        {
            (null, "GET") => service.GetRequestInformation(context.Request),
            ("header", "GET") => service.GetHeaderInformation(context.Request),
            ("add", "GET") => service.QueryParameters(context.Request),
            ("content", "GET") => service.Content(context.Request),
            ("form", "GET" or "POST") => service.Form(context.Request),
            ("writecookie", "GET") => service.WriteCookie(context.Response),
            ("readcookie", "GET") => service.ReadCookie(context.Request),
            ("json", "GET") => service.GetJson(context.Response),
            _ => string.Empty
        };

        if (action is "json")
        {
            await context.Response.WriteAsync(result);
        }
        else
        {
            var doc = result.HtmlDocument("Request and Response Samples");
            await context.Response.WriteAsync(doc);
        }
    });
    endpoints.Map("/add/{x:int}/{y:int}", async context =>
    {
        //GetRouteValue - ���������� nullable ������ ��� ���������� �����������
        int x = int.Parse(context.GetRouteValue("x")?.ToString() ?? "0");
        int y = int.Parse(context.GetRouteValue("y")?.ToString() ?? "0");
        await context.Response.WriteAsync($"The result of {x} + {y} is {x + y}");
    });
    endpoints.Map("/session", async context =>
    {
        //Microsoft.Extensions.DependencyInjection
        var service = context.RequestServices.GetRequiredService<SessionSample>();
        await service.SessionAsync(context);
    });
    endpoints.MapGet("/", async context =>
    {
        string[] lines = new[]
        {
                        @"<ul>",
                          @"<li><a href=""/hello.html"">Static Files</a> - requires UseStaticFiles</li>",
                          @"<li><a href=""/add/37/5"">Route Constraints</a></li>",
                          @"<li>Request and Response:",
                            @"<ul>",
                              @"<li><a href=""/randr"">Request and Response</a></li>",
                              @"<li><a href=""/randr/header"">Request headers</a></li>",
                              @"<li><a href=""/randr/add?x=38&y=4"">Add</a></li>",
                              @"<li><a href=""/randr/content?data=sample"">Content</a></li>",
                              @"<li><a href=""/randr/content?data=<h1>Heading 1</h1>"">HTML Content</a></li>",
                              @"<li><a href=""/randr/content?data=<script>alert('hacker');</script>"">Bad Content</a></li>",
                              @"<li><a href=""/randr/encoded?data=<h1>sample</h1>"">Encoded content</a></li>",
                              @"<li><a href=""/randr/encoded?data=<script>alert('hacker');</script>"">Encoded bad Content</a></li>",
                              @"<li><a href=""/randr/form"">Form</a></li>",
                              @"<li><a href=""/randr/writecookie"">Write cookie</a></li>",
                              @"<li><a href=""/randr/readcookie"">Read cookie</a></li>",
                              @"<li><a href=""/randr/json"">JSON</a></li>",
                            @"</ul>",
                          @"</li>",
                          @"<li><a href=""/session"">Session</a></li>",
                        @"</ul>"
                };

        StringBuilder sb = new();
        foreach (var line in lines)
        {
            sb.Append(line);
        }
        string html = sb.ToString().HtmlDocument("Web Sample App");

        await context.Response.WriteAsync(html);
    });
});

app.Run();