using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(cfg => cfg.AddJsonFile("appsettings.json", true, true))
    .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("appsettings.json", true, true))
    .UseOrleans(silo => silo.UseLocalhostClustering())
    .UseConsoleLifetime();

using var host = builder.Build();

await host.RunAsync();


Console.WriteLine("End.");
return;
