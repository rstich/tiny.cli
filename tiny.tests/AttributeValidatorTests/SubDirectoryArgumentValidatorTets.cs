using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class SubDirectoryArgumentValidatorTets
{
    [Fact]
    public void NoArguments_Returns_TopDirectoryOnly()
    {
        var args = Array.Empty<string>();
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response == SearchOption.TopDirectoryOnly.ToString());
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void WrongArguments_Returns_TopDirectoryOnly()
    {
        var args = new []{ "-unsupported"};
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response == SearchOption.TopDirectoryOnly.ToString());
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void SubDirectoryArgument_Simple_Returns_AllDirectories()
    {
        var args = new[] { Parameter.SubDirectory.Simple };
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response == SearchOption.AllDirectories.ToString());
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void SubDirectoryArgument_Complex_Returns_AllDirectories()
    {
        var args = new[] { Parameter.SubDirectory.Complex };
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response == SearchOption.AllDirectories.ToString());
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void TooManyArguments_Returns_Message()
    {
        var args = new[] { Parameter.SubDirectory.Simple, Parameter.SubDirectory.Complex };
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.False(sut.IsValid);
        Assert.True(response == SearchOption.TopDirectoryOnly.ToString());
        Assert.False(string.IsNullOrEmpty(sut.Message));
    }
}