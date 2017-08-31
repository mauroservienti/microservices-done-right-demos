using Marketing.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Marketing.API.Controllers
{
    [RoutePrefix("api/available")]
    public class AvailableProductsController : ApiController
    {
        [HttpGet]
        [Route("products")]
        public IEnumerable<int> Get()
        {
            using (var db = new MarketingContext())
            {
                var all = db.ProductsDetails
                    .Select(p => p.ProductId)
                    .ToArray();

                return all;
            }
        }
    }
}
