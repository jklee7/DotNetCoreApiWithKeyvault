using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreApiWithKeyvault.Settings;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DotNetCoreApiWithKeyvault
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var builtConfig = config.Build();
                    var keyvaultSettings = new KeyvaultSettings();
                    builtConfig.Bind("Keyvault", keyvaultSettings);

                    var keyVaultConfig = new ConfigurationBuilder()
                        .AddAzureKeyVault(
                            keyvaultSettings.Uri,
                            keyvaultSettings.AppId,
                            keyvaultSettings.Secret)
                        .Build();
                    config.AddConfiguration(keyVaultConfig);
                })
                .UseStartup<Startup>();
    }
}
