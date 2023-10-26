if (args.Length == 0)
{
    Console.WriteLine("No arguments provided. Exiting.");
    return;
}

IProblemHandler? problemHandler;

var argumentProcessor = new ArgumentProcessor();
problemHandler = argumentProcessor.ChooseHandler(args);
argumentProcessor.Process(args, problemHandler);