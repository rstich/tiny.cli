using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class SubDirectoryArgumentValidatorTets
{
    [Fact]
    public void NoArguments_Returns_TopDirectoryOnly()
    {
        var args = Array.Empty<string>();
        var workFlowParams = new WorkFlowParameters();
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.SearchOption == SearchOption.TopDirectoryOnly);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void WrongArguments_Returns_TopDirectoryOnly()
    {
        var args = new []{ "-unsupported"};
        var workFlowParams = new WorkFlowParameters();
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.SearchOption == SearchOption.TopDirectoryOnly);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void SubDirectoryArgument_Simple_Returns_AllDirectories()
    {
        var args = new[] { Parameter.SubDirectory.Simple };
        var workFlowParams = new WorkFlowParameters();
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.SearchOption == SearchOption.AllDirectories);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void SubDirectoryArgument_Complex_Returns_AllDirectories()
    {
        var args = new[] { Parameter.SubDirectory.Complex };
        var workFlowParams = new WorkFlowParameters();
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.SearchOption == SearchOption.AllDirectories);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void TooManyArguments_Returns_Message()
    {
        var args = new[] { Parameter.SubDirectory.Simple, Parameter.SubDirectory.Complex };
        var workFlowParams = new WorkFlowParameters();
        var sut = new SubDirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.SearchOption);
        Assert.False(string.IsNullOrEmpty(sut.Message));
    }
}