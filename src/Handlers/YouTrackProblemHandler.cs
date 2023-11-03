using TreeOfThought.Abstractions;

namespace TreeOfThought.Handlers;

public class YouTrackProblemHandler : IProblemHandler
{
    // Todo: push member up
    public string Name => nameof(YouTrackProblemHandler);
    public IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; } = new List<ProblemSolvingCapability>();

    public void HandleProblem(string description)
    {
        Console.WriteLine($"Answer from youtrack: {description}");
    }
}