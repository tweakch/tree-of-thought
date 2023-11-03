using TreeOfThought.Abstractions;

namespace TreeOfThought.Handlers;

public class GitHubProblemHandler : IProblemHandler
{
    // Todo: push member up
    public string Name => nameof(GitHubProblemHandler);
    public IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; } = new List<ProblemSolvingCapability>();

    public void HandleProblem(string description)
    {
        // do nothing
    }
}