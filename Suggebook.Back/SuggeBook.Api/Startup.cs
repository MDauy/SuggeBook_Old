using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuggeBook.AutoMapperProfiles;
using SuggeBook.IoC;

namespace SuggeBook.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string CorsSpecificOrigins = "AllowAll";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(CorsSpecificOrigins, 
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3006");
                    });
            });
            services.AddCors();
            services.DeclareMaps();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ViewModelValidationFilter));
            });
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.InjectRepositories();
            services.InjectUseCases();
            services.InjectBaseRepositories();

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            
            //Microsoft.AspNetCore.Mvc.MvcOptions.EnableEndpointRouting = false;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(CorsSpecificOrigins);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }

    }
}
