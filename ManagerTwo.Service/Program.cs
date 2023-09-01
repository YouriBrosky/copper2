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
                .AddSingleton<ManagerTwo>()
                .BuildServiceProvider();

            // Retrieve the MyClass instance from the DI container
            var managerTwo = serviceProvider.GetRequiredService<ManagerTwo>();

            // Use the MyClass instance
            await managerTwo.GetSomePeople(5);

            Console.WriteLine("Done!");
        }
    }
}