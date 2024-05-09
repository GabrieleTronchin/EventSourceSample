using EventSource.Application.Orders.Commands;
using EventSource.Application.Orders.Queries;
using EventSource.Presentation.Orders.Events;
using Microsoft.AspNetCore.Mvc;

namespace EventSource.Presentation.Orders;

public static class OrderEndpoint
{
    public static void AddOrdersEnpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "All",
                async (ISender sender) =>
                {
                    var result = await sender.Send(
                        new GetAllOrdersCommand() { SeachOnDescription = null }
                    );
                    return Results.Ok(result);
                }
            )
            .WithOpenApi();

        app.MapGet(
                "Search/{search}",
                async (ISender sender, string search) =>
                {
                    var result = await sender.Send(
                        new GetAllOrdersCommand() { SeachOnDescription = search }
                    );
                    return Results.Ok(result);
                }
            )
            .WithOpenApi();

        app.MapGet(
                "Live/{orderId}",
                async (ISender sender, Guid orderId) =>
                {
                    var result = await sender.Send(
                        new GetOrderLiveProjectionCommand() { OrderId = orderId }
                    );
                    return Results.Ok(result);
                }
            )
            .WithOpenApi();

        app.MapGet(
                "Snapshot/{orderId}",
                async (ISender sender, Guid orderId) =>
                {
                    var result = await sender.Send(
                        new GetOrderSnapshotProjectionCommand() { OrderId = orderId }
                    );
                    return Results.Ok(result);
                }
            )
            .WithOpenApi();

        app.MapPost(
            "/createNewOrder",
            async ([FromBody] CreateOrderRequest request, ISender sender) =>
            {
                CreateOrderCommand createOrderCommand = new() { Description = request.Description };

                var result = await sender.Send(createOrderCommand);

                return Results.Created();
            }
        );
    }
}
