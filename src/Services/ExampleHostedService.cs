using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TreeOfThought.Abstractions;
using TreeOfThought.Handlers;

namespace TreeOfThought.Services;

public sealed class ExampleHostedService : IHostedService
{
    private readonly ILogger _logger;

    public ExampleHostedService(
        ILogger<ExampleHostedService> logger,
        IHostApplicationLifetime appLifetime)
    {
        _logger = logger;

        appLifetime.ApplicationStarted.Register(OnStarted);
        appLifetime.ApplicationStopping.Register(OnStopping);
        appLifetime.ApplicationStopped.Register(OnStopped);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("1. StartAsync has been called");
        
        string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();

        if (args.Length == 0)
        {
            _logger.LogInformation("No arguments provided. Exiting");
            Environment.Exit(0);
            return Task.CompletedTask;
        }

        var handlers = new Dictionary<string, IProblemHandler>
        {
            { "file", new FileAndFolderProblemHandler() },
            { "console", new ConsoleProblemHandler() },
            { "youtrack", new YouTrackProblemHandler() },
            { "github", new GitHubProblemHandler() }
        };

        var chooser = new HandlerChooser(handlers);

        // choose the handler
        var problemHandler = chooser.ChooseHandler(args);

        // intialize the argument processor
        var argumentProcessor = new ArgumentProcessor();

        // process the arguments
        argumentProcessor.Process(args, problemHandler);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("4. StopAsync has been called");

        return Task.CompletedTask;
    }

    private void OnStarted()
    {
        _logger.LogInformation("2. OnStarted has been called");
    }

    private void OnStopping()
    {
        _logger.LogInformation("3. OnStopping has been called");
    }

    private void OnStopped()
    {
        _logger.LogInformation("5. OnStopped has been called");
    }
}