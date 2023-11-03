using TreeOfThought;
using TreeOfThought.Abstractions;
using TreeOfThought.Handlers;

namespace tree_of_thought_tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ChooseHandler_Returns_YouTrackHandler_When_Args_Is_YouTrack()
    {
        // Arrange
        var chooser = new HandlerChooser();

        // Act
        var handler = chooser.ChooseHandler(new string[]{"--handler", "youtrack"});
        
        // Assert
        Assert.AreEqual("YouTrackProblemHandler", handler.GetType().Name);
    }

    [Test]
    public void ChooseHandler_Returns_GithubHandler_When_Args_Is_Handler_Github()
    {
        // Arrange
        HandlerChooser chooser = new HandlerChooser();

        // Act
        var handler = chooser.ChooseHandler(new string[]{"--handler", "github"});
        
        // Assert
        Assert.AreEqual("GitHubProblemHandler", handler.GetType().Name);
    }

    [Test]
    public void ChooseHandler_Returns_FileHandler_When_Args_Is_Empty()
    {
        // Arrange
        IChooseHandler chooser = new HandlerChooser();

        // Act
        var handler = chooser.ChooseHandler(new string[]{});
        
        // Assert
        Assert.AreEqual(nameof(FileAndFolderProblemHandler), handler.GetType().Name);
    }

    [Test]
    public void ChooseHandler_Returns_TestHandler()
    {
        // Arrange
        IChooseHandler chooser = new TestChooser();

        // Act
        var handler = chooser.ChooseHandler(new string[]{});
        
        // Assert
        Assert.AreEqual(nameof(TestHandler), handler.GetType().Name);
    }
}