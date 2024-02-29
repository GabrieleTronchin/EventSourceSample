using EventSource.Application.Rider.Commands;
using EventSource.Presentation.Rider.Events;
using Microsoft.AspNetCore.Mvc;


namespace EventSource.Presentation.Rider;

public static class RiderEndpoint
{
    public static void AddRiderEnpoint(this IEndpointRouteBuilder app)
    {


        app.MapPut("/acceptOrder", async ([FromBody] AcceptOrderRequest request, ISender sender) =>
        {

            AcceptOrderCommand createOrderCommand = new() { Id = request.OrderId };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });


        app.MapPut("/updateLocation", async ([FromBody] UpdateLocationRequest request, ISender sender) =>
        {

            UpdateLocationCommand createOrderCommand = new()
            {
                RirderId = request.RirderId,
                Latitute = request.Latitute,
                Longitude = request.Longitude
            };

            var result = await sender.Send(createOrderCommand);

            return Results.Created();

        });

    }

}
