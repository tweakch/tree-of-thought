interface IProblemHandler
{
    string Name { get; }
    void HandleProblem(string description);
}
