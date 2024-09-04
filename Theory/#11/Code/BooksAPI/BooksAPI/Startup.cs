using Books.Models;
using BooksAPI.Services;

namespace BooksAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get;}
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "BooksApi", Version = "v3" });
            });
            services.AddSingleton<IBookChapterService, BookChapterService>();
            services.AddScoped<SampleChapters>();
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v3/swagger.json", "BooksApi v3"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/init", async context =>
                {
                    var sampleChapters = context.RequestServices.GetRequiredService<SampleChapters>();
                    sampleChapters.CreateSampleChapters();
                    await context.Response.WriteAsync("sample chapters initialized");
                });
            });
        }
    }
}
