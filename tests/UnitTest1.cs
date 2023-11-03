using TreeOfThought;
using TreeOfThought.Abstractions;
using TreeOfThought.Handlers;

namespace tree_of_thought_tests;

public class Tests
{
    // TODO: make typed collection
    private readonly Dictionary<string, IProblemHandler> _handlers = new Dictionary<string, IProblemHandler>
    {
        {"file", new FileAndFolderProblemHandler()},
        {"console", new ConsoleProblemHandler()},
        {"youtrack", new YouTrackProblemHandler()},
        {"github", new GitHubProblemHandler()},
    };
    
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ChooseHandler_Returns_YouTrackHandler_When_Args_Is_YouTrack()
    {
        // Arrange
        var chooser = new HandlerChooser(_handlers);

        // Act
        var handler = chooser.ChooseHandler(new string[]{"--handler", "youtrack"});
        
        // Assert
        Assert.That(handler?.GetType().Name, Is.EqualTo("YouTrackProblemHandler"));
    }

    [Test]
    public void ChooseHandler_Returns_GithubHandler_When_Args_Is_Handler_Github()
    {
        // Arrange
        var chooser = new HandlerChooser(_handlers);

        // Act
        var handler = chooser.ChooseHandler(new string[]{"--handler", "github"});
        
        // Assert
        Assert.That(handler?.GetType().Name, Is.EqualTo("GitHubProblemHandler"));
    }

    [Test]
    public void ChooseHandler_Returns_FileHandler_When_Args_Is_Empty()
    {
        // Arrange
        var chooser = new HandlerChooser(_handlers);

        // Act
        var handler = chooser.ChooseHandler(new string[]{});
        
        // Assert
        Assert.That(handler?.GetType().Name, Is.EqualTo(nameof(FileAndFolderProblemHandler)));
    }

    [Test]
    public void ChooseHandler_Returns_TestHandler()
    {
        // Arrange
        IChooseHandler chooser = new TestChooser();

        // Act
        var handler = chooser.ChooseHandler(new string[]{});
        
        // Assert
        Assert.That(handler?.GetType().Name, Is.EqualTo(nameof(TestHandler)));
    }
}