using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TreeOfThought;
using TreeOfThought.Abstractions;
using TreeOfThought.Handlers;
using TreeOfThought.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddCommandLine(args);
builder.Configuration.AddJsonFile("appsettings.json", false);

// TODO: Dependency Injection

// builder.Services.AddSingleton<IChooseHandler, TestChooser>();

// variante 1: factory approach
builder.Services.AddSingleton<HandlerChooser>(_ =>
{
    var handlers = new Dictionary<string, IProblemHandler>
    {
        { "file", new FileAndFolderProblemHandler() },
        { "console", new ConsoleProblemHandler() },
        { "youtrack", new YouTrackProblemHandler() },
        { "github", new GitHubProblemHandler() }
    };
    return new HandlerChooser(handlers);
});

// variante 2: service approach
// var handlers = new Dictionary<string, IProblemHandler>
// {
//     { "file", new FileAndFolderProblemHandler() },
//     { "console", new ConsoleProblemHandler() },
//     { "youtrack", new YouTrackProblemHandler() },
//     { "github", new GitHubProblemHandler() }
// };
// builder.Services.AddSingleton(handlers);

builder.Services.AddHostedService<ExampleHostedService>();



// TODO: 
builder.Configuration.AddCommandLine(args);

using var host = builder.Build();

await host.RunAsync();