using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Sales.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpointName = "Sales.Services";
            Console.Title = endpointName;
            MainAsync(endpointName).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string endpointName)
        {
            await Task.CompletedTask;
        }
    }
}
