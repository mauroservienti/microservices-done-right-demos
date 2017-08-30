using Marketing.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Marketing.API.Controllers
{
    [RoutePrefix("api/orders")]
    public class ProductsDetailsController : ApiController
    {
        [HttpGet]
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
        public IEnumerable<dynamic> Get(int pageIndex, int pageSize)
        {
            using (var db = new MarketingContext())
            {
                var items = db.ProductsDetails
                    .OrderBy(p => p.Name)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .ToArray();

                return items;
            }
        }
    }
}
