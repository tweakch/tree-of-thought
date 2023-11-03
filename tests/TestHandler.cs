using TreeOfThought.Abstractions;

namespace tree_of_thought_tests;

public class TestHandler : IProblemHandler
{
    public string Name { get; } = "test";
    public void HandleProblem(string description)
    {
        // do nothing
    }
}