using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Warehouse.Data.Context;

namespace Warehouse.Data.Migrations
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<WarehouseContext>
    {
        protected override void Seed(WarehouseContext context)
        {
            context.StockItems.AddOrUpdate(k => k.Id, Initial.Data().ToArray());
        }
    }
}
