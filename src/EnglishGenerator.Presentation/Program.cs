using System.Text.Json.Serialization;
using EnglishGenerator.Core;
using EnglishGenerator.Infrastructure;
using EnglishGenerator.Presentation;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureInfrastructure()
    .ConfigureCore()
    .ConfigurePresentation()
    .AddFastEndpoints();

var app = builder.Build();

app.UseFastEndpoints(configAction => configAction.Serializer.Options.Converters.Add(new JsonStringEnumConverter()));
app.Run();

public partial class Program { }