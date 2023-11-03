using TreeOfThought.Abstractions;

namespace tree_of_thought_tests;

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