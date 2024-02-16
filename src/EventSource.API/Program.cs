using System.Text.Json.Serialization;
using EventSource.Application;
using EventSource.Application.Account;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();



var todosApi = app.MapGroup("/todos");
todosApi.AddForecastModelEndpoint();

app.Run();

