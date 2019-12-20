using System.IO;
using HamgoonAPI.DataContext;
using HamgoonAPIV1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Hamgoon.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.ConfigureHamgoon(Configuration);
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , HamgooonMySQLContext context)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
           Path.Combine("/hamgoonImages")),
                RequestPath = new PathString("/images")
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine("/hamgoonImages")),
                RequestPath = new PathString("/images")
            });


            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
                
            app.UseAuthentication();
            
            app.UseMvc();
            
        }
    }
}
