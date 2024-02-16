using EventSource.Application.Orders.Commands;


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
        });


        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
        {

            CreateOrderCommand createOrderCommand = new CreateOrderCommand();
            //TODO Map request to command

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });

    }

}
