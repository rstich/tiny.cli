namespace tiny.tests;

public class ArgumentValidatorTests
{
    /*
    private readonly ArgumentValidationService _sut = new();

    [Fact]
    public void NoArguments_Returns_Null()
    {
        var arguments = Array.Empty<string>();
        var commands = _sut.ValidateArguments(arguments);
        Assert.Null(commands);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var arguments = new []{ "-unsupported"};
        var commands = _sut.ValidateArguments(arguments);
        Assert.Null(commands);
    }
    
    [Fact]
    public void HelpArgument_Simple_Returns_HelpMessage()
    {
        var arguments = new[] { "-h" };
        var commands = _sut.ValidateArguments(arguments);
        Assert.True(commands?.HelpMessage is not null);
    }
    
    [Fact]
    public void HelpArgument_Complex_Returns_HelpMessage()
    {
        var arguments = new[] { "--help" };
        var commands = _sut.ValidateArguments(arguments);
        Assert.True(commands?.HelpMessage is not null);
    }
    
    [Fact]
    public void SingleFileArgument_Simple_Returns_SingleFile()
    {
        string fileName = "test.jpg";
        var arguments = new[] { "-f", fileName };
        var commands = _sut.ValidateArguments(arguments);
        Assert.True(commands?.SingleFile is not null && commands.SingleFile == fileName);
    }
    
    [Fact]
    public void SingleFileArgument_Complex_Returns_SingleFile()
    {
        string fileName = "test.jpg";
        var arguments = new[] { "--file", fileName };
        var commands = _sut.ValidateArguments(arguments);
        Assert.True(commands?.SingleFile is not null && commands.SingleFile == fileName);
    }
    */
}