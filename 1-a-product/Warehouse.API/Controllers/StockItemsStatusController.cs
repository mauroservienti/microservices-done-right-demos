using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Warehouse.Data.Context;

namespace Warehouse.API.Controllers
{
    [RoutePrefix("api/stockitems")]
    public class ProductsPricesController : ApiController
    {
        [HttpGet]
        [Route("status/{id}")]
        public dynamic Get(int id)
        {
            using (var db = new WarehouseContext())
            {
                var item = db.StockItems
                    .Where(o => o.ProductId == id)
                    .SingleOrDefault();

                return item;
            }
        }

        [HttpGet]
        [Route("statuses/{ids}")]
        public IEnumerable<dynamic> Get(string ids)
        {
            using (var db = new WarehouseContext())
            {
                var productIds = ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
                var items = db.StockItems
                    .Where(status => productIds.Any(id => id == status.ProductId))
                    .ToArray();

                return items;
            }
        }
    }
}
