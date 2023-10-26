if (args.Length == 0)
{
    Console.WriteLine("No arguments provided. Exiting.");
    return;
}

IProblemHandler? problemHandler;

// intialize the argument processor
var argumentProcessor = new ArgumentProcessor();

// choose the handler
problemHandler = ArgumentProcessor.ChooseHandler(args);

// process the arguments
argumentProcessor.Process(args, problemHandler);
