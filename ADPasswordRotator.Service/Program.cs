// See https://aka.ms/new-console-template for more information
using ADPasswordRotator.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddHttpClient<UpdateService>(client =>
                  {
                      client.BaseAddress = new Uri("https://localhost:7168/");
                  });
                  services.AddHostedService<UpdateHostService>();
              });
    }
}