using ITOps.ViewModelComposition;
using ITOps.ViewModelComposition.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.ViewModelComposition
{
    class AddToCartPostHandler : IHandleRequests
    {
        public bool Matches(RouteData routeData, string httpVerb, HttpRequest request)
        {
            var controller = (string)routeData.Values["controller"];
            var action = (string)routeData.Values["action"];

            return HttpMethods.IsPost(httpVerb)
                   && controller.ToLowerInvariant() == "products"
                   && action.ToLowerInvariant() == "addtocart"
                   && routeData.Values.ContainsKey("id");
        }

        public async Task Handle(dynamic vm, RouteData routeData, HttpRequest request)
        {
            var postData = new
            {
                ProductId = (string)routeData.Values["id"],
                CartId = 1 //this should come from a cookie or from a session or stored in the user account
            };

            var url = $"http://localhost:20298/api/shopping-cart";
            var client = new HttpClient();
            var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(response.ReasonPhrase);
            }
        }
    }
}