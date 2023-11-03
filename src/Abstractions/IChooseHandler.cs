namespace TreeOfThought.Abstractions;

public interface IChooseHandler
{
    IProblemHandler? ChooseHandler(string[] args);
    string ContainsHandler(string[] args);
}