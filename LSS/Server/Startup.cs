using AutoMapper;
using LSS.Server;
using LSS.Server.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;
using System;

namespace LSS.Server
{
  public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();

			services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration
				.GetConnectionString("DefaultConnection")));

			services.AddAutoMapper(typeof(Startup));

			services.AddDatabaseDeveloperPageExceptionFilter();

			/** 
			 * uncomment next 2 if rather save blobs 
			 * to Server proj's wwwroot than in azure storage
			services.AddScoped<IFileStorageService, InAppStorageService>();
			services.AddHttpContextAccessor(); 
			*/
			 /** uncomment next if rather save blobs in azure storage */
			services.AddScoped<IFileStorageService, AzureStorageService>();
			
			services.AddAutoMapper(typeof(Startup));
			services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      services.AddAzureClients(builder =>
      {
        builder.AddBlobServiceClient(Configuration["ConnectionStrings:AzureStorageConnection:blob:blob"], preferMsi: true);
        builder.AddQueueServiceClient(Configuration["ConnectionStrings:AzureStorageConnection:blob:queue"], preferMsi: true);
      });

    }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
        endpoints.MapFallbackToFile("index.html");

        //https://andrewlock.net/enabling-prerendering-for-blazor-webassembly-apps/
        //endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
  internal static class StartupExtensions
  {
    public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
    {
      if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
      {
        return builder.AddBlobServiceClient(serviceUri);
      }
      else
      {
        return builder.AddBlobServiceClient(serviceUriOrConnectionString);
      }
    }
    public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
    {
      if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
      {
        return builder.AddQueueServiceClient(serviceUri);
      }
      else
      {
        return builder.AddQueueServiceClient(serviceUriOrConnectionString);
      }
    }
  }
}
