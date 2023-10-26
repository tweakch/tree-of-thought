class ConsoleProblemHandler : IProblemHandler
{
    public void HandleProblem(string description)
    {
        Console.WriteLine($"# Problem Description\n\n{description}\n\n## Branches\n\nThis is a console-based tree of thought.");
    }
}