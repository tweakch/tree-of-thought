using TreeOfThought.Abstractions;

namespace TreeOfThought.Handlers;

internal class GitHubProblemHandler : IProblemHandler
{
    public string Name { get; }
    public IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; } = new List<ProblemSolvingCapability>();

    public void HandleProblem(string description)
    {
        // do nothing
    }
}