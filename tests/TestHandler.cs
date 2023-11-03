using TreeOfThought.Abstractions;

namespace TreeOfThought.Tests;

public class TestHandler : IProblemHandler
{
    public string Name => "test";
    public IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; } = new List<ProblemSolvingCapability>();

    public void HandleProblem(string description)
    {
        // do nothing
    }
}