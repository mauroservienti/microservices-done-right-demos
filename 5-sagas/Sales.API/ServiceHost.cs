using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace Sales.API
{
    class ServiceHost
    {
        IDisposable webApp;

        public void Start()
        {
            var baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            webApp = WebApp.Start<Startup>(url: baseAddress);
            ServiceBus.Start();

            Console.WriteLine($"Sales.API listening on {baseAddress}");
        }

        public void Stop()
        {
            webApp?.Dispose();
            ServiceBus.Instance?.Stop().GetAwaiter().GetResult();
        }
    }
}
