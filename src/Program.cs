using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TreeOfThought.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<ExampleHostedService>();

// TODO: 
builder.Configuration.AddCommandLine(args);

using var host = builder.Build();

await host.RunAsync();