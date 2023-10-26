
// Single responsibility (no) => next
// open/closed (ja) 
// Liskov substitution (ja)
// Interface segregation (ja)
// dependency inversion (no)  => next.next


class ArgumentProcessor : IProcess
{
    private static Dictionary<string, IProblemHandler> _handlers = new Dictionary<string, IProblemHandler>
    {
        {"file", new FileAndFolderProblemHandler()},
        {"console", new ConsoleProblemHandler()},
    };

    protected static string ContainsHandler(string[] args)
    {
        return args[Array.IndexOf(args, "--handler") + 1];
    }

    public static IProblemHandler? ChooseHandler(string[] args)
    {
        string handlerKey = args.Contains("--handler") ? ContainsHandler(args) : "file";
        return _handlers.ContainsKey(handlerKey) ? _handlers[handlerKey] : null;
    }

    public void Process(string[] args, IProblemHandler? problemHandler)
    {
        if (problemHandler == null)
        {
            Console.WriteLine("Invalid handler specified. Exiting.");
            return;
        }

        if (args[0] == "--problem" && args.Length > 1 && args.Contains("--tree-of-thought"))
        {
            string problemDescription = args[1];
            problemHandler.HandleProblem(problemDescription);

            Console.WriteLine("Processed problem description.");
        }
        else
        {
            Console.WriteLine("Invalid arguments. Exiting.");
        }
    }
}