using TreeOfThought.Abstractions;

namespace TreeOfThought.Handlers;

class ConsoleProblemHandler : IProblemHandler
{
    public string Name => nameof(ConsoleProblemHandler);
    public IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; } = Array.Empty<ProblemSolvingCapability>();

    public void HandleProblem(string description)
    {
        Console.WriteLine($"# Problem Description\n\n{description}\n\n## Branches\n\nThis is a console-based tree of thought.");
    }
}