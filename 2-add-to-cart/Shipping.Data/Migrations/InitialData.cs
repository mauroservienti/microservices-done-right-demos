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
                Price = 2.50m,
                EligibleForFreeShipping = false
            };

            yield return new ShippingDetails()
            {
                ProductId = 2,
                Price = 0.00m,
                EligibleForFreeShipping = true
            };
        }

    }
}
