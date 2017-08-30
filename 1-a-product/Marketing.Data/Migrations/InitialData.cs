using Marketing.Data.Models;
using System.Collections.Generic;

namespace Marketing.Data.Migrations
{
    internal static class Initial
    {
        internal static IEnumerable<ProductDetails> Data()
        {
            yield return new ProductDetails()
            {
                ProductId = 1,
                Name = "Banana Holder",
                Description = "Outdoor travel cute banana protector storage box"
            };

            yield return new ProductDetails()
            {
                ProductId = 2,
                Name = "Nokia Lumia 635",
                Description = "Amazing phone, unfortunately not understood by market"
            };
        }

    }
}
