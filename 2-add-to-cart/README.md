# Demo 1 - Single Item ViewModel Composition

## Scenario 1

Composition gateway action as a reverse proxy.

Ensure the following projects are set as startup projects:

* CompositionGateway
* Marketing.API
* Sales.API
* Warehouse.API

Run the project, via a REST Client such as Postman hit the following URL http://localhost:4457/products/details/1 the returned json is composed by data coming from different APIs

## Scenario 2

Hosting the composition engine inside a regular MVC Application

Ensure the following projects are set as startup projects:

- WebApp
- Marketing.API
- Sales.API
- Warehouse.API

Run the project and navigate the web app