using EventSource.Application.Account;
using EventSource.Presentation.Forecast;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var myApiGroup = app.MapGroup("/v1");
myApiGroup.AddForecastModelEndpoint();

app.Run();

