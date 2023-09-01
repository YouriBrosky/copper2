﻿using Microsoft.Extensions.DependencyInjection;
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
                .AddSingleton<ManagerOne>()
                .BuildServiceProvider();

            // Retrieve the MyClass instance from the DI container
            var managerOne = serviceProvider.GetRequiredService<ManagerOne>();

            // Use the MyClass instance
            await managerOne.GetSomePeople(5);

            Console.WriteLine("Done!");
        }
    }
}