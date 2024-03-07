# Sample Food Delivery API With Marten

Project Objective: Simulate a Food Delivery Application.

Main Entities:
- Order
- Rider

Flow Description:

1. An order is initially created with a default status (New).
2. A rider accpet an order, event stream start and an OrderAccepted event is dispatched.
3. The rider updates their location to track the order's progress, a LocationUpdate event is dispatched for each new location.
4. The Order Aggregate entity reflects the result of order and rider updates.
    There are two ways to retrieve an aggregate:
      1. Live Aggregation:  Evaluate all events from the database each time you request the data.
      2. Snapshot Aggregation: Store in memory using mattern.

 ## Minimal API with AOT Compilation
 
> Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core.

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0

> Publishing your app as Native AOT produces an app that's self-contained and that has been ahead-of-time (AOT) compiled to native code. Native AOT apps have faster startup time and smaller memory footprints. These apps can run on machines that don't have the .NET runtime installed.

https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=net7%2Cwindows

NOTE: Marten and projection can't work with aot compilation casue dynamic generetated code is not allowed.


 ## Event Sourcing and CQRS in Microservices

**What is CQRS?**

> Command Query Responsibility Segregation (CQRS) is a pattern that separates the read and write operations of a system into distinct paths. In a CQRS architecture, commands represent requests to change the system’s state, while queries fetch data for reading purposes. By segregating these concerns, CQRS allows optimization of each path independently, enabling efficient scaling, performance tuning, and enhanced user experiences.

https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs

To implement the CQRS pattern, a Mediator Library is employed to manage Queries and Commands.

> Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between objects. The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.

https://github.com/jbogard/MediatR

https://refactoring.guru/design-patterns/mediator

In combination with mediatR I use FluentValidation to validate Queries and Commands before they hit the handlers.

> A validation library for .NET that uses a fluent interface and lambda expressions for building strongly-typed validation rules.

https://github.com/FluentValidation/FluentValidation


**Event Sourcing**

> Event Sourcing, at its core, is a data storage pattern that captures every change to an application’s state as a sequence of immutable events. Unlike traditional approaches that store only the current state, Event Sourcing maintains a full history of state changes. This technique not only enables you to reconstruct the application’s past states but also provides an audit trail of how and why the system arrived at its current state.

To implement the EventSource pattern on this project I use martendb.

Some info about:

> Marten is a .NET library that allows developers to use the Postgresql database as both a document database and a fully-featured event store -- with the document features serving as the out-of-the-box mechanism for projected "read side" views of your events.

- https://martendb.io


**Benefits of Event Sourcing and CQRS in Microservices**

The combination of Event Sourcing and CQRS offers several advantages when applied to microservices-based applications:

1. Historical Transparency: Event Sourcing ensures a comprehensive record of all state changes, providing historical transparency for auditing, compliance, and debugging purposes.
2. Flexibility in Query Optimization: CQRS empowers you to optimize read and write paths differently. This means you can tailor the read path for query performance while optimizing the write path for high throughput.
3. Scalability and Performance: Microservices architectures demand efficient scaling. Event Sourcing and CQRS allow you to scale different parts of your application independently, enhancing overall performance.
4. Resilience and Fault Tolerance: Event Sourcing enhances resilience by allowing the reconstruction of application state after a failure. CQRS helps isolate errors and failures in the write path from affecting the read path.
5. Support for Complex Domains: Event Sourcing allows you to capture complex domain behavior accurately by recording fine-grained events. CQRS then enables tailored views of this data for various use cases.

## DDD

> Domain-driven design (DDD) is a software design approach that focuses on modeling the software to match the domain, or the subject area, that the software is intended for. DDD helps developers create software that is aligned with the business needs and terminology of the domain experts, users, and stakeholders.

**Why Choose DDD?** 
1. Clarity of Business Logic: With DDD, the main business logic becomes the star of the show. It helps in keeping the core application logic free from the distractions of the UI and database code.
2. Improved Communication: DDD uses a shared “Ubiquitous Language” that both developers and non-developers (like stakeholders or business experts) understand. It bridges the gap between the technical and non-technical members of a team.
3. Flexibility & Scalability: DDD results in a modular and loosely-coupled design, making it easier to make changes and scale the application in the future.
4. Quality Software: With a clear focus on the domain, there’s a better chance of getting the business logic right, leading to fewer bugs and improved software quality.

## Test

**Unit Test**

//TODO
Conduct testing with NSubstitute for MOQ.

**Mutation Test**

An important metric in our code base is the code coverage percentage. This KPI is used to ascertain the percentage of code covered by automated tests.
Another KPI that we can combine with it is the mutator score KPI. To detect this score, you should run some mutator tests.
Mutation testing is used to design new software tests and evaluate the quality of existing software tests.

On this project i integrate this test using Stryker. You can run the powershell on src folder to try it.

## Docker and Docker Compose

Navigate to the 'docker' folder to access the Docker Compose file, facilitating the deployment of your persistence layer.

## Usefull links

[Rancher Desktop](https://rancherdesktop.io/): a free and comercial use for docker and/or Kubernates in local


