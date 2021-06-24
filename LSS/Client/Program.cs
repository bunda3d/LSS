using LSS.Client.Auth;
using LSS.Client.Helpers;
using LSS.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LSS.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

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
      services.AddScoped<IAccountsRepository, AccountsRepository>();
      services.AddAuthorizationCore();

      //when using SAME instance of JWTAuthStProv for multiple srvcs: 
      services.AddScoped<JWTAuthenticationStateProvider>();
      //srvc1
      services.AddScoped<AuthenticationStateProvider, 
        JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
        );
      //srvc2
      services.AddScoped<ILoginService, 
        JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
        );

    }
  }
}