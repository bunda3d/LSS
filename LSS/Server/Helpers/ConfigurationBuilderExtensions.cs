using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace LSS.Server.Helpers
{
  public static class ConfigurationBuilderExtensions
  {

    public static void ConfigureKeyVault(this IConfigurationBuilder config)
    {
      string? keyVaultEndpoint = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");

      if (keyVaultEndpoint is null)
        throw new InvalidOperationException("Store the Key Vault endpoint in a KEYVAULT_ENDPOINT environment variable.");

      var secretClient = new SecretClient(new(keyVaultEndpoint), new DefaultAzureCredential());
      config.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
    }

    public static void WriteConfigurationSources(this IConfigurationBuilder config)
    {
      Console.WriteLine("Configuration sources\n=====================");
      foreach (var source in config.Sources)
      {
        if (source is JsonConfigurationSource jsonSource)
          Console.WriteLine($"{source}: {jsonSource.Path}");
        else
          Console.WriteLine(source.ToString());
      }
      Console.WriteLine("=====================\n");
    }

  }
}
