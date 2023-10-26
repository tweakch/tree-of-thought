
// Single responsibility (no) => next
// open/closed (ja) 
// Liskov substitution (ja)
// Interface segregation (ja)
// dependency inversion (no)  => next.next

interface IProcess{
    void Process(string[] args, IProblemHandler? problemHandler);
}
