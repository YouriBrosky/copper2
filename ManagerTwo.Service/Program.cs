using Microsoft.Extensions.DependencyInjection;
using ManagerOne.Interface;

namespace ManagerTwo.Service
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<HttpClient>()
                .AddSingleton<IManagerOne>(sp => new HttpProxy(sp.GetRequiredService<HttpClient>()))
                .AddSingleton<MyCaller>()
                .BuildServiceProvider();

            // Retrieve the MyClass instance from the DI container
            var myClass = serviceProvider.GetRequiredService<MyCaller>();

            // Use the MyClass instance
            await myClass.Call(5);

            Console.WriteLine("Done!");
        }
    }
}