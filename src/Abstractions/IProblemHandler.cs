using TreeOfThought.Handlers;

namespace TreeOfThought.Abstractions;

public interface IProblemHandler
{
    string Name { get; }
    IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; }
    void HandleProblem(string description);
}