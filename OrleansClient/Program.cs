
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using OrleansInterfaces;

Console.WriteLine("Wait...");
Console.ReadLine();

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(cfg => cfg.AddJsonFile("appsettings.json", true, true))
    .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("appsettings.json", true, true))
    .UseOrleansClient(client => client.UseLocalhostClustering())
    .UseConsoleLifetime();

using var host = builder.Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();

var friend = client.GetGrain<IHello>(0);
var response = await friend.SayHello("Hi friend!");

Console.WriteLine($"""
                   {response}

                   Press any key to exit...
                   """);

Console.ReadKey();

await host.StopAsync();

Console.WriteLine("End.");
return;
