using System.Collections.Immutable;
using TreeOfThought.Abstractions;

namespace TreeOfThought.Handlers;

public class FileAndFolderProblemHandler : IProblemHandler
{
    public string Name => "FileAndFolderProblemHandler";
    public IReadOnlyList<ProblemSolvingCapability>? Capabilities { get; } = new List<ProblemSolvingCapability>();

    public void HandleProblem(string description)
    {
        CreateProblemMd(description);
        CreateProblemFolder();
    }

    private void CreateProblemMd(string description)
    {
        string problemMdContent = $"# Problem Description\n\n{description}\n\n## Branches\n\n[Link to branches](./problem/)";
        File.WriteAllText("problem.md", problemMdContent);
    }

    private void CreateProblemFolder()
    {
        Directory.CreateDirectory("problem");
    }
}