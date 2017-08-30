using Shipping.Data.Migrations;
using Shipping.Data.Models;
using System.Data.Entity;

namespace Shipping.Data.Context
{
    public class ShippingContext : DbContext
    {
        public ShippingContext() : base("Shpping")
        {
        }

        public IDbSet<ShippingDetails> ProductsShippingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());

            modelBuilder.Entity<ShippingDetails>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
