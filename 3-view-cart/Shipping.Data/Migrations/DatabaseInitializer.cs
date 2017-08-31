using Shipping.Data.Context;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Shipping.Data.Migrations
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<ShippingContext>
    {
        protected override void Seed(ShippingContext context)
        {
            context.ProductsShippingDetails.AddOrUpdate(k => k.Id, Initial.Data().ToArray());
        }
    }
}
