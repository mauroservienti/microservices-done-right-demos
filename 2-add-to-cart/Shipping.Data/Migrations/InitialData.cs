using Shipping.Data.Models;
using System.Collections.Generic;

namespace Shipping.Data.Migrations
{
    internal static class Initial
    {
        internal static IEnumerable<ShippingDetails> Data()
        {
            yield return new ShippingDetails()
            {
                ProductId = 1,
                Cost = 2.50m,
                FreeShippingEligible = false
            };

            yield return new ShippingDetails()
            {
                ProductId = 2,
                Cost = 0.00m,
                FreeShippingEligible = true
            };
        }

    }
}
