
// Single responsibility (no) => next
// => refactoring to patterns: 
// 1. Introduce Interface ("")
// 2. Extract class ("")
// 3. Extract method ("")

// open/closed (ja) 
// Liskov substitution (ja)
// Interface segregation (ja)
// dependency inversion (no)  => next.next

using TreeOfThought.Abstractions;

namespace TreeOfThought;

public class ArgumentProcessor : IProcess
{
    public void Process(string[] args, IProblemHandler? problemHandler)
    {
        if (problemHandler == null)
        {
            Console.WriteLine("Invalid handler specified. Exiting.");
            return;
        }

        if (args[0] == "--problem" && args.Length > 1)
        {
            string problemDescription = args[1];
            problemHandler.HandleProblem(problemDescription);

            Console.WriteLine("Processed problem description.");
        }
        else
        {
            Console.WriteLine("Invalid arguments. Exiting.");
        }
    }
}