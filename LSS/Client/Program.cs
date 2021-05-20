using LSS.Client.Helpers;
using LSS.Client.Repository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			ConfigureServices(builder.Services);


			await builder.Build().RunAsync();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			//register all client services
			services.AddTransient<IRepository, RepositoryInMemory>();
			services.AddScoped<IHttpService, HttpService>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IPersonRepository, PersonRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
		}
	}
}
