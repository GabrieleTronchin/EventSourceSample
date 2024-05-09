using EventSource.Application;
using EventSource.Application.Account;
using EventSource.Presentation.Orders;
using EventSource.Presentation.Rider;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var order = app.MapGroup("/v1/order");

order.AddOrdersEnpoint();

var rider = app.MapGroup("/v1/rider");
rider.AddRiderEnpoint();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
