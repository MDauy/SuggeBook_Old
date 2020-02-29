using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.InjectRepositories();
            services.InjectUseCases();
            services.InjectBaseRepositories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsSpecificOrigins);
            app.UseMvc();
        }

    }
}
