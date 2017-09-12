using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace Shipping.API
{
    class ServiceHost
    {
        IDisposable webApp;

        public void Start()
        {
            var baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            webApp = WebApp.Start<Startup>(url: baseAddress);
            ServiceBus.Start();

            Console.WriteLine($"Shipping.API listening on {baseAddress}");
        }

        public void Stop()
        {
            if (webApp != null)
            {
                webApp.Dispose();
                ServiceBus.Instance?.Stop().GetAwaiter().GetResult();
            }
        }
    }
}
