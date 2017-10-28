using ITOps.ViewModelComposition;
using ITOps.ViewModelComposition.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Sales.ViewModelComposition.Events;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marketing.ViewModelComposition
{
    class ShoppingCartGetHandler : IHandleRequests
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

        public async Task Handle(string requestId, dynamic vm, RouteData routeData, HttpRequest request)
        {
            var id = 1;

            var url = $"http://localhost:20296/api/shopping-cart/{id}";
            var client = new HttpClient();
            var response = await client.GetAsync(url).ConfigureAwait(false);

            dynamic shoppingCart = await response.Content.AsExpandoAsync().ConfigureAwait(false);

            if (shoppingCart.Items.Count == 0)
            {
                vm.CartId = id;
                vm.CartItems = new List<dynamic>();

                return;
            }

            IDictionary<dynamic, dynamic> cartItemsViewModel = MapToDictionary(shoppingCart.Items);

            await vm.RaiseEvent(new ShoppingCartItemsLoaded()
            {
                CartId = shoppingCart.CartId,
                CartItemsViewModel = cartItemsViewModel
            }).ConfigureAwait(false);

            vm.CartId = shoppingCart.CartId;
            vm.CartItems = cartItemsViewModel.Values.ToList();
        }

        IDictionary<dynamic, dynamic> MapToDictionary(IEnumerable<object> cartItems)
        {
            var cartItemsViewModel = new Dictionary<dynamic, dynamic>();

            foreach (dynamic item in cartItems)
            {
                dynamic vm = new ExpandoObject();
                vm.ProductId = item.ProductId;
                vm.ProductPrice = item.ProductPrice;
                vm.Quantity = item.Quantity;
                vm.TotalPrice = item.ProductPrice * item.Quantity;

                cartItemsViewModel[item.ProductId] = vm;
            }

            return cartItemsViewModel;
        }
    }
}
