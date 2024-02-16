using EventSource.Application.Orders.Commands;
using Microsoft.AspNetCore.Mvc;


namespace EventSource.Presentation.Orders;

public static class OrderModel
{
    public static void AddForecastModelEndpoint(this IEndpointRouteBuilder app)
    {

        app.MapGet("/orders", async (ISender sender) =>
        {
            //TODO Define Query Commands
            var result = await sender.Send(default);
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
