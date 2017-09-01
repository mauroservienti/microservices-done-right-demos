using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace ITOps.ViewModelComposition
{
    class Subscription<T> : Subscription
    {
        private Func<dynamic, T, RouteData, HttpRequest, Task> subscription;

        public Subscription(Func<dynamic, T, RouteData, HttpRequest, Task> subscription)
        {
            this.subscription = subscription;
        }

        public override Task Invoke(dynamic viewModel, object @event, RouteData routeData, HttpRequest request) => subscription(viewModel, (T)@event, routeData, request);
    }
}
