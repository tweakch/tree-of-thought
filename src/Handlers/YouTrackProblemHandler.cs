using TreeOfThought.Abstractions;

namespace TreeOfThought.Handlers;

public class ProblemSolvingCapability
{
    public string Description { get; set; }
    public string Branches { get; set; }
    public string Solution { get; set; }
    public string[] Tags { get; set; } = new string[0];
    public string[] Links { get; set; } = new string[0];
    public string[] Files { get; set; } = new string[0];
    public string[] Folders { get; set; } = new string[0];
    public string[] Images { get; set; } = new string[0];
    public string[] Videos { get; set; } = new string[0];
}

class YouTrackProblemHandler : IProblemHandler
{
    public string Name => nameof(YouTrackProblemHandler);
    
    public IReadOnlyList<ProblemSolvingCapability> Capabilities { get; } = new[]
    {
        new ProblemSolvingCapability() { Description = "I know how to create User Stories", }
    }.ToList();
    
    public void HandleProblem(string description)
    {
        Console.WriteLine($"Answer from youtrack: {description}");
    }
}