using ManagerOne.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

static class Program
{
    static async Task Main(string[] args)
    {
        // Setup dependency injection
        var serviceProvider = new ServiceCollection()
            .AddSingleton<HttpClient>()
            .AddSingleton<IManagerOne>(sp => new HttpProxy(sp.GetRequiredService<HttpClient>()))
            .AddSingleton<ConsoleApp>()
            .BuildServiceProvider();

        // Retrieve the ConsoleApp instance from the DI container
        var consoleApp = serviceProvider.GetRequiredService<ConsoleApp>();

        // Use the ConsoleApp instance
        await consoleApp.GetSomePeople(5);

        Console.WriteLine("Done!");
    }
}