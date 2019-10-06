using System.IO;
using AudiobookLibrary.Core.Confguration;
using AudiobookLibrary.Web.BackgroundTasks;
using AudiobookLibrary.Web.Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace AudiobookLibrary.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // In production, the Angular files will be served from this directory
//            services.AddSpaStaticFiles(configuration =>
//            {
//                configuration.RootPath = "ClientApp/dist";
//            });

            services.AddSignalR();
            

            //            services.AddSwaggerGen(c =>
            //            {
            //                c.SwaggerDoc("v1", new Info
            //                {
            //                    Version = "v1",
            //                    Title = "Templates API",
            //                    Description = "API for Templates application",
            //                    TermsOfService = "None",
            //                    Contact = new Contact { Name = "", Email = "" },
            //                });
            //
            //                //Set the comments path for the swagger json and ui.
            //                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //                c.IncludeXmlComments(xmlPath);
            //            });

            IFileProvider physicalFileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            ConfigurationFacade.Configure(services, Configuration, physicalFileProvider);
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            var webAssembly = typeof(Startup).Assembly;
            services.AddMediatR(webAssembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseFileServer();
            //            app.UseHttpsRedirection();
            app.UseStaticFiles();
//            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<LibraryHub>("/library");
            });
            //            app.UseMvc(routes =>
            //            {
            //                routes.MapRoute(
            //                    name: "default",
            //                    template: "{controller}/{action=Index}/{id?}");
            //            });

//            app.UseSpa(spa =>
//            {
//                // To learn more about options for serving an Angular SPA from ASP.NET Core,
//                // see https://go.microsoft.com/fwlink/?linkid=864501
//
//                spa.Options.SourcePath = "ClientApp";
//
//                if (env.IsDevelopment())
//                {
//                    spa.UseAngularCliServer(npmScript: "start");
//                }
//            });

//            app.UseSwagger();
//
//            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
//            app.UseSwaggerUI(c =>
//            {
//                var endpoint = "./v1/swagger.json";
//                c.SwaggerEndpoint(endpoint, "Audiobook API V1");
//                //c.RoutePrefix = string.Empty;
//            });
        }
    }
}
