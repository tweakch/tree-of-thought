using TreeOfThought.Abstractions;
using TreeOfThought.Handlers;

namespace TreeOfThought;

public class HandlerChooser : IChooseHandler
{
    private readonly Dictionary<string, IProblemHandler> _handlers;
    
    //TODO: next properties
    
    public HandlerChooser(Dictionary<string, IProblemHandler> handlers)
    {
        _handlers = handlers;
    }

    public string ContainsHandler(string[] args)
    {
        return args[Array.IndexOf(args, "--handler") + 1];
    }

    public IProblemHandler? ChooseHandler(string[] args)
    {
        // Smells like primitive obsession
        string handlerKey = args.Contains("--handler") ? ContainsHandler(args) : "file";
        return _handlers.ContainsKey(handlerKey) ? _handlers[handlerKey] : null;
    }
    
    
}