using System.Data.Entity;
using Warehouse.Data.Migrations;
using Warehouse.Data.Models;

namespace Warehouse.Data.Context
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext() : base("Warehouse")
        {
        }

        public IDbSet<StockItem> StockItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());

            modelBuilder.Entity<StockItem>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
