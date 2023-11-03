using TreeOfThought.Abstractions;
using TreeOfThought.Handlers;

namespace tree_of_thought_tests;

public class TestHandler : IProblemHandler
{
    public string Name => "test";
    public IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; } = new List<ProblemSolvingCapability>();

    public void HandleProblem(string description)
    {
        // do nothing
    }
}