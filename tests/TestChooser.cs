using TreeOfThought.Abstractions;

namespace TreeOfThought.Tests;

public class TestChooser : IChooseHandler
{
    public IProblemHandler? ChooseHandler(string[] args)
    {
        return new TestHandler();
    }

    public string ContainsHandler(string[] args)
    {
        return "test";
    }
}