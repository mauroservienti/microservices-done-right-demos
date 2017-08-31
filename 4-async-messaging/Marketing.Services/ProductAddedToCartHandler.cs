using System;
using System.Threading.Tasks;
using NServiceBus;
using Sales.Messages.Events;

namespace Marketing.Services
{
    class ProductAddedToCartHandler : IHandleMessages<ProductAddedToCart>
    {
        public Task Handle(ProductAddedToCart message, IMessageHandlerContext context)
        {
            var backup = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Product {message.ProductId} added to CartId {message.CartId}");

            Console.ForegroundColor = backup;

            return Task.CompletedTask;
        }
    }
}
