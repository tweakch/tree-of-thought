using TreeOfThought;
using TreeOfThought.Abstractions;
using TreeOfThought.Handlers;

if (args.Length == 0)
{
    Console.WriteLine("No arguments provided. Exiting.");
    return;
}

var handlers = new Dictionary<string, IProblemHandler>
{
    {"file", new FileAndFolderProblemHandler()},
    {"console", new ConsoleProblemHandler()},
    {"youtrack", new YouTrackProblemHandler()},
    {"github", new GitHubProblemHandler()},
};

var chooser = new HandlerChooser(handlers);

// choose the handler
var problemHandler = chooser.ChooseHandler(args);

// intialize the argument processor
// TODO: 
var argumentProcessor = new ArgumentProcessor();

// process the arguments
argumentProcessor.Process(args, problemHandler);
