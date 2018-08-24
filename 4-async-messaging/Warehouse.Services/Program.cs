using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Warehouse.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpointName = "Warehouse.Services";
            Console.Title = endpointName;
            MainAsync(endpointName).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string endpointName)
        {
            await Task.CompletedTask;
        }
    }
}
