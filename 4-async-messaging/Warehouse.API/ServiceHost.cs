using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace Warehouse.API
{
    class ServiceHost
    {
        IDisposable webApp;

        public void Start()
        {
            var baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            webApp = WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine($"Warehouse.API listening on {baseAddress}");
        }

        public void Stop()
        {
            if (webApp != null)
            {
                webApp.Dispose();
            }
        }
    }
}
