using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering()
            //.ConfigureLogging(logging => logging.AddConsole())
            ;
    })
    .UseConsoleLifetime();

using var host = builder.Build();

await host.RunAsync();


Console.WriteLine("End.");
return;
