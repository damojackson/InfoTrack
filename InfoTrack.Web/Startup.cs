using InfoTrack.Business.Factory;
using InfoTrack.Business.Services;
using InfoTrack.Core.Entities;
using InfoTrack.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.Web
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
            services.AddRazorPages();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InfoTrackTest.Web", Version = "v1" });
            });

            // register the fatcory.
            services.AddScoped<SearchEngineFactory>();

            // Add the HttpClient.
            services.AddScoped<HttpClient>();

            // Add the SearchSettings that are set in the app settings.
            var config = new SearchSettings();
            Configuration.Bind("SearchSettings", config);
            services.AddSingleton(config);

            // Add the search service.
            services.AddScoped<ISearchService, SearchService>();

            // add each of the search engine services so they are resolvable suing the factory.
            services.AddScoped<GoogleSearchService>()
                        .AddScoped<ISearchEngineService, GoogleSearchService>(s => s.GetService<GoogleSearchService>());

            services.AddScoped<BingSearchService>()
                        .AddScoped<ISearchEngineService, BingSearchService>(s => s.GetService<BingSearchService>());
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InfoTrackTest.Web v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
