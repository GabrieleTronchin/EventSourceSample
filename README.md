# Sample Food Delivery API With Marten

## Project Objective
The aim of this project is to simulate a Food Delivery Application.

### Main Entities
- Order
- Rider

### Flow Description
1. An order is initially created with a default status (New).
2. A rider accepts an order, triggering an event stream start and dispatching an OrderAccepted event.
3. The rider updates their location to track the order's progress, with a LocationUpdate event dispatched for each new location.
4. The Order Aggregate entity reflects the result of order and rider updates. There are two ways to retrieve an aggregate:
   - Live Aggregation: Evaluating all events from the database each time you request the data.
   - Snapshot Aggregation: Stored in memory using Marten.

## Minimal API with AOT Compilation
Minimal APIs are designed for creating HTTP APIs with minimal dependencies, ideal for microservices and applications requiring minimal files, features, and dependencies in ASP.NET Core. [Learn more](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0)

Publishing your app as Native AOT produces a self-contained app that's been ahead-of-time (AOT) compiled to native code. Native AOT apps boast faster startup times and smaller memory footprints, and they can run on machines without the .NET runtime installed. [Learn more](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=net7%2Cwindows)

Note: Marten and projection cannot work with AOT compilation because dynamically generated code is not allowed.

## Event Sourcing and CQRS in Microservices

### What is CQRS?
Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. [Learn more](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)

To implement the CQRS pattern, a Mediator Library is employed to manage Queries and Commands. [MediatR](https://github.com/jbogard/MediatR)

In combination with MediatR, FluentValidation is used to validate Queries and Commands before they hit the handlers. [FluentValidation](https://github.com/FluentValidation/FluentValidation)

### Event Sourcing
Event Sourcing captures every change to an application’s state as a sequence of immutable events, maintaining a full history of state changes. [Learn more](https://martendb.io)

## Benefits of Event Sourcing and CQRS in Microservices
The combination of Event Sourcing and CQRS offers several advantages:
1. Historical Transparency
2. Flexibility in Query Optimization
3. Scalability and Performance
4. Resilience and Fault Tolerance
5. Support for Complex Domains

## DDD
Domain-driven design (DDD) focuses on modeling software to match the domain or subject area that the software is intended for. [Learn more](https://refactoring.guru/design-patterns/mediator)

### Why Choose DDD?
1. Clarity of Business Logic
2. Improved Communication
3. Flexibility & Scalability
4. Quality Software

## Test
### Unit Test
Conduct testing with NSubstitute for MOQ.

### Mutation Test
To evaluate the quality of existing software tests, mutation testing with Stryker is integrated into the project.

## Docker and Docker Compose
Navigate to the 'docker' folder to access the Docker Compose file, facilitating the deployment of your persistence layer.

## Useful Links
[Rancher Desktop](https://rancherdesktop.io/): A free and commercial tool for Docker and/or Kubernetes in a local environment.
