using EventSource.Application.Orders.Commands;
using EventSource.Application.Orders.Queries;
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


        app.MapPost("/orders", async ([FromBody] CreateOrderRequest request, ISender sender) =>
        {

            CreateOrderCommand createOrderCommand = new CreateOrderCommand() { Description = request.Description };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });

    }

}
