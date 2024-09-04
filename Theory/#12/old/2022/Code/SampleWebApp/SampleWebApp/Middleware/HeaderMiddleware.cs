namespace SampleWebApp.Middleware
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next) => _next = next;

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("CustomHeader2", "custom header value");
            return _next(httpContext);
        }
    }

    // Метод расширения, используемый для добавления middleware в конвейер HTTP-запросов.
    public static class HeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseHeaderMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<HeaderMiddleware>();
    }
}
