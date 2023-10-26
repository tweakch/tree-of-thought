class FileAndFolderProblemHandler : IProblemHandler
{
    public string Name => nameof(FileAndFolderProblemHandler);

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
