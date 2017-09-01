# Demo 4 - (Micro)services async communication

Ensure the following projects are set as startup projects:

* WebApp
* Marketing.API
* Marketing.Services
* Sales.API
* Warehouse.API
* Warehouse.Services
* Shipping.API
* Shipping.Services

Run the project and navigate the web app, add some items to the shopping cart. Look at the code handling messages in `Marketing.Services` and `Warehouse.Services`.

Take also a look at the error handling logic `in RequestsHandlers` that handle the `AddToCart` action.