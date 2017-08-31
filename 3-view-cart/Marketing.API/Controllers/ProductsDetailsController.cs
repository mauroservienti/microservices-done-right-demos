using Marketing.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Marketing.API.Controllers
{
    [RoutePrefix("api/product-details")]
    public class ProductsDetailsController : ApiController
    {
        [HttpGet]
        [Route("product/{id}")]
        public dynamic Get(int id)
        {
            using (var db = new MarketingContext())
            {
                var item = db.ProductsDetails
                    .Where(o => o.ProductId == id)
                    .SingleOrDefault();

                return item;
            }
        }

        [HttpGet]
        [Route("products/{ids}")]
        public IEnumerable<dynamic> Get(string ids)
        {
            using (var db = new MarketingContext())
            {
                var productIds = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
                var items = db.ProductsDetails
                    .Where(status => productIds.Any(id => id == status.ProductId))
                    .ToArray();

                return items;
            }
        }
    }
}
