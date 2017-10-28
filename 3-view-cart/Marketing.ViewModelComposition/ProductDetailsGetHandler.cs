﻿using ITOps.ViewModelComposition;
using ITOps.ViewModelComposition.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marketing.ViewModelComposition
{
    class ProductDetailsGetHandler : IHandleRequests
    {
        public bool Matches(RouteData routeData, string httpVerb, HttpRequest request)
        {
            var controller = (string)routeData.Values["controller"];
            var action = (string)routeData.Values["action"];

            return HttpMethods.IsGet(httpVerb)
                   && controller.ToLowerInvariant() == "products"
                   && action.ToLowerInvariant() == "details"
                   && routeData.Values.ContainsKey("id");
        }

        public async Task Handle(string requestId, dynamic vm, RouteData routeData, HttpRequest request)
        {
            var id = (string)routeData.Values["id"];

            var url = $"http://localhost:20295/api/product-details/product/{id}";
            var client = new HttpClient();
            var response = await client.GetAsync(url).ConfigureAwait(false);

            dynamic productDetails = await response.Content.AsExpandoAsync().ConfigureAwait(false);

            vm.ProductId = productDetails.ProductId;
            vm.ProductName = productDetails.Name;
            vm.ProductDescription = productDetails.Description;
        }
    }
}