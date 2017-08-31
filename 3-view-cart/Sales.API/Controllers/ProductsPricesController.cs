using Sales.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Sales.API.Controllers
{
    [RoutePrefix("api/prices")]
    public class ProductsPricesController : ApiController
    {
        [HttpGet]
        [Route("product/{id}")]
        public dynamic Get(int id)
        {
            using (var db = new SalesContext())
            {
                var item = db.ProductsPrices
                    .Where(o => o.ProductId == id)
                    .SingleOrDefault();

                return item;
            }
        }

        [HttpGet]
        [Route("products/{ids}")]
        public IEnumerable<dynamic> Get(string ids)
        {
            using (var db = new SalesContext())
            {
                var productIds = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
                var items = db.ProductsPrices
                    .Where(status => productIds.Any(id => id == status.ProductId))
                    .ToArray();

                return items;
            }
        }
    }
}
