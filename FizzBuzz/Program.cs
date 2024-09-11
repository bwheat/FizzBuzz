using Lamar.Microsoft.DependencyInjection;
using Asp.Versioning.ApiExplorer;
using FizzBuzz.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLamar((context, registry) =>
{
    registry.IncludeRegistry(DefaultRegistry.GetRegistry());
});
builder.Services.AddControllers().AddNewtonsoftJson();

var startUp = new FizzBuzz.Startup(builder.Configuration);
startUp.ConfigureServices(builder.Services);

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
startUp.Configure(app, builder.Environment, provider);


app.Run();

