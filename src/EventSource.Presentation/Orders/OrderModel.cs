using EventSource.Application.Orders.Commands;
using EventSource.Application.Orders.Queries;
using EventSource.Presentation.Orders.Events;
using Microsoft.AspNetCore.Mvc;


namespace EventSource.Presentation.Orders;

public static class OrderModel
{
    public static void AddOrdersEnpoint(this IEndpointRouteBuilder app)
    {

        app.MapGet("/orders", async (ISender sender) =>
        {
            //TODO Define Query Commands
            var result = await sender.Send(new GetAllOrdersCommand());
            return Results.Ok(result);
        }).WithOpenApi();


        app.MapPost("/createNewOrder", async ([FromBody] CreateOrderRequest request, ISender sender) =>
        {

            CreateOrderCommand createOrderCommand = new CreateOrderCommand() { Description = request.Description };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });


        app.MapPut("/orderReady", async ([FromBody] OrderReadyRequest request, ISender sender) =>
        {

            OrderReadyCommand createOrderCommand = new OrderReadyCommand() { Id = request.OrderId };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });

        app.MapPut("/acceptOrder", async ([FromBody] AcceptOrderRequest request, ISender sender) =>
        {

            AcceptOrderCommand createOrderCommand = new AcceptOrderCommand() { Id = request.OrderId };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });



        app.MapPut("/confirmOrder", async ([FromBody] ConfirmOrderRequest request, ISender sender) =>
        {

            ConfirmOrderCommand createOrderCommand = new ConfirmOrderCommand() { Id = request.OrderId };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });

    }

}
