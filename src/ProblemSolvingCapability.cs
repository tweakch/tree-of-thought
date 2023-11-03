namespace TreeOfThought.Handlers;

public class ProblemSolvingCapability
{
    public ProblemSolvingCapability(string description)
    {
        Description = description;
    }
    
    public string Description { get; set; }
    public List<string>? Tags { get; set; }
}