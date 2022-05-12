using Microsoft.Extensions.DependencyInjection;
using Petstore.List.BusinessLogic;
using Petstore.List.DataLayer;
using Petstore.List.Model;
using System;
using System.Collections.Generic;

namespace Petstore.List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IPetstoreService, PetstoreService>();
            services.AddSingleton<PetstoreLogic>();
            var serviceProvider = services.BuildServiceProvider();

            var logic = serviceProvider.GetService<PetstoreLogic>();
            List<Pet> pets = logic.GetAvailablePets();

            string catergory = string.Empty;
            int serial = 1;
            foreach(Pet pet in pets)
            {
                if(catergory != pet.Category.Name)
                {
                    Console.WriteLine($"Catergory: {pet.Category.Name}");
                    Console.WriteLine(new string('=', 20));
                    serial = 1;
                }
                Console.WriteLine($"{serial++}. {pet.Name}");
                catergory = pet.Category.Name;
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"Press any key to close this window");
            Console.ReadLine();
        }
    }
}
