using EventSource.Application.Orders.Commands;
using EventSource.Application.Orders.Queries;
using EventSource.Presentation.Orders.Events;
using Microsoft.AspNetCore.Mvc;


namespace EventSource.Presentation.Orders;

public static class OrderEndpoint
{
    public static void AddOrdersEnpoint(this IEndpointRouteBuilder app)
    {

        app.MapGet("/orders/{search?}", async (ISender sender, string? search) =>
        {
            var result = await sender.Send(new GetAllOrdersCommand() { SeachOnDescription = search });
            return Results.Ok(result);
        }).WithOpenApi();


        app.MapPost("/createNewOrder", async ([FromBody] CreateOrderRequest request, ISender sender) =>
        {

            CreateOrderCommand createOrderCommand = new() { Description = request.Description };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });


        app.MapPut("/orderReady", async ([FromBody] OrderReadyRequest request, ISender sender) =>
        {

            OrderReadyCommand createOrderCommand = new() { Id = request.OrderId };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });

        app.MapPut("/acceptOrder", async ([FromBody] AcceptOrderRequest request, ISender sender) =>
        {

            AcceptOrderCommand createOrderCommand = new() { Id = request.OrderId };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });



        app.MapPut("/confirmOrder", async ([FromBody] ConfirmOrderRequest request, ISender sender) =>
        {

            ConfirmOrderCommand createOrderCommand = new() { Id = request.OrderId };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });

    }

}
