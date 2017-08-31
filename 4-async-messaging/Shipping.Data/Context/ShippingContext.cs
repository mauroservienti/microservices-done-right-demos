using Shipping.Data.Migrations;
using Shipping.Data.Models;
using System.Data.Entity;

namespace Shipping.Data.Context
{
    public class ShippingContext : DbContext
    {
        public ShippingContext() : base("Shipping")
        {
        }

        public IDbSet<ShippingDetails> ProductsShippingDetails { get; set; }

        public IDbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());

            modelBuilder.Entity<ShippingDetails>();
            modelBuilder.Entity<ShoppingCartItem>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
