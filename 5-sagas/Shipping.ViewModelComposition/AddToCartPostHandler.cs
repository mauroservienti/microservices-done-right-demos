using ITOps.ViewModelComposition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using NServiceBus;
using Shipping.Messages.Commands;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.ViewModelComposition
{
    class AddToCartPostHandler : IHandleRequests, IHandleRequestsErrors
    {
        IMessageSession messageSession;

        public AddToCartPostHandler(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        public bool Matches(RouteData routeData, string httpVerb, HttpRequest request)
        {
            var controller = (string)routeData.Values["controller"];
            var action = (string)routeData.Values["action"];

            return HttpMethods.IsPost(httpVerb)
                   && controller.ToLowerInvariant() == "products"
                   && action.ToLowerInvariant() == "addtocart"
                   && routeData.Values.ContainsKey("id");
        }

        public async Task Handle(string requestId, dynamic vm, RouteData routeData, HttpRequest request)
        {
            var postData = new
            {
                ProductId = (string)routeData.Values["id"],
                Quantity = int.Parse(request.Form["quantity"][0]), //should check is > 0
                CartId = 1 //this should come from a cookie or from a session or stored in the user account
            };

            var url = $"http://localhost:20298/api/shopping-cart";
            var client = new HttpClient();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json")
            };
            requestMessage.Headers.Add("request-id", requestId);

            var response = await client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(response.ReasonPhrase);
            }
        }

        public Task OnRequestError(string requestId, Exception ex, dynamic vm, RouteData routeData, HttpRequest request)
        {
            return messageSession.Send("Shipping.Services", new CleanupCart()
            {
                ProductId = int.Parse((string)routeData.Values["id"]),
                CartId = 1, //this should come from a cookie or from a session or stored in the user account
                RequestId = requestId
            });
        }
    }
}
