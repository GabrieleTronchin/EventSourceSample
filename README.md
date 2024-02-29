# Sample project Include Marten Db (Postgres), CQRS, WebAPI

Project Objective: Simulate a Food Delivery Application.

Main Entities:
- Order
- Rider
Flow Description:

1. An order is initially created with a default status (New).
2. A rider can accept an order.
3. The rider updates their location to track the order's progress.
4. The status and location of the order are retrieved through projections.

## Tech involved

 ### Minimal API with AOT Compilation
 
> Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core.

> Publishing your app as Native AOT produces an app that's self-contained and that has been ahead-of-time (AOT) compiled to native code. Native AOT apps have faster startup time and smaller memory footprints. These apps can run on machines that don't have the .NET runtime installed.

 ### CQRS

> CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update operations for a data store. Implementing CQRS in your application can maximize its performance, scalability, and security.

 ### EventSource with Marten

> Marten is a .NET library that allows developers to use the Postgresql database as both a document database and a fully-featured event store -- with the document features serving as the out-of-the-box mechanism for projected "read side" views of your events.

- https://martendb.io

### DDD

> Domain-driven design (DDD) is a software design approach that focuses on modeling the software to match the domain, or the subject area, that the software is intended for. DDD helps developers create software that is aligned with the business needs and terminology of the domain experts, users, and stakeholders.

### MediatoR

> Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between objects. The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.

https://github.com/jbogard/MediatR

https://refactoring.guru/design-patterns/mediator

### Fluent Validation using Mediator Pipeline

> A validation library for .NET that uses a fluent interface and lambda expressions for building strongly-typed validation rules.

https://github.com/FluentValidation/FluentValidation

### Usefull links

[Rancher Desktop](https://rancherdesktop.io/): a free and comercial use for docker and/or Kubernates in local
