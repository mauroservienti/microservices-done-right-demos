using NServiceBus;
using Sales.Messages.Events;
using System;
using System.Threading.Tasks;

namespace Sales.Services
{
    class ShopingCartSaga : Saga<ShopingCartSaga.ShopingCartSagaData>,
        IHandleMessages<ProductAddedToCart>,
        IHandleTimeouts<CartGettingStaleTimeout>,
        IHandleTimeouts<CartWipeTimeout>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ShopingCartSagaData> mapper)
        {
            mapper.ConfigureMapping<ProductAddedToCart>(msg => msg.CartId).ToSaga(data => data.CartId);
        }

        public class ShopingCartSagaData : ContainSagaData
        {
            public int CartId { get; set; }
            public DateTime LastTouched { get; set; }
        }

        public async Task Handle(ProductAddedToCart message, IMessageHandlerContext context)
        {
            Data.LastTouched = DateTime.Now;

            await RequestTimeout(context, Data.LastTouched.AddDays(7), new CartGettingStaleTimeout()
            {
                LastTouched = Data.LastTouched
            });

            await RequestTimeout(context, Data.LastTouched.AddMonths(1), new CartWipeTimeout()
            {
                LastTouched= Data.LastTouched
            });
        }

        public Task Timeout(CartGettingStaleTimeout state, IMessageHandlerContext context)
        {
            if (Data.LastTouched <= state.LastTouched)
            {
                //send e-mail
                //publish event CartGotStaleDueToInactivity
            }

            return Task.CompletedTask;
        }

        public Task Timeout(CartWipeTimeout state, IMessageHandlerContext context)
        {
            if (Data.LastTouched <= state.LastTouched)
            {
                //publish event CartWipedDueToInactivity
                //delete cart content
                //MarkAsComplete();
            }

            return Task.CompletedTask;
        }
    }

    class CartGettingStaleTimeout
    {
        public DateTime LastTouched { get; set; }
    }

    class CartWipeTimeout
    {
        public DateTime LastTouched { get; set; }
    }
}
