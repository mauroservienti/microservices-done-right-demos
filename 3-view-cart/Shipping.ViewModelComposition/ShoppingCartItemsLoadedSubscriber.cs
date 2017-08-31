using ITOps.ViewModelComposition;
using ITOps.ViewModelComposition.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Sales.ViewModelComposition.Events;
using System;
using System.Net.Http;

namespace Shipping.ViewModelComposition
{
    public class ShoppingCartItemsLoadedSubscriber : ISubscribeToCompositionEvents
    {
        public bool Matches(RouteData routeData, string httpVerb, HttpRequest request)
        {
            var controller = (string)routeData.Values["controller"];
            var action = (string)routeData.Values["action"];

            return HttpMethods.IsGet(httpVerb)
                   && controller.ToLowerInvariant() == "shoppingcart"
                   && action.ToLowerInvariant() == "index"
                   && !routeData.Values.ContainsKey("id");
        }

        public void Subscribe(ISubscriptionStorage subscriptionStorage, RouteData routeData, HttpRequest request)
        {
            subscriptionStorage.Subscribe<ShoppingCartItemsLoaded>(async (pageViewModel, @event, rd, req) =>
            {
                var ids = String.Join(",", @event.CartItemsViewModel.Keys);

                var url = $"http://localhost:20298/api/shopping-cart/products/{ids}";
                var client = new HttpClient();

                var response = await client.GetAsync(url).ConfigureAwait(false);

                dynamic[] shippingDetails = await response.Content.AsExpandoArrayAsync().ConfigureAwait(false);

                foreach (dynamic detail in shippingDetails)
                {
                    @event.CartItemsViewModel[detail.ProductId].ProductShippingCost = detail.ShippingCost;
                    @event.CartItemsViewModel[detail.ProductId].ProductEligibleForFreeShipping = detail.FreeShippingEligible;
                }
            });
        }
    }
}
