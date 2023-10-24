using Tiny.Cli;
using Tiny.Cli.Misc;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class OutPutDirArgumentValidatorTests
{
    [Fact]
    public void NoArguments_Returns_CurrentDir()
    {
        var args = Array.Empty<string>();
        var workFlowParams = new WorkFlowParameters();
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.OutPutDir == Environment.CurrentDirectory);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var args = new []{ "-unsupported"};
        var workFlowParams = new WorkFlowParameters();
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.OutPutDir == Environment.CurrentDirectory);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void OutPutDirArgument_Simple_Returns_OutPutDir()
    {
        var args = new[] { Parameter.OutPutDir.Simple, "C:\\temp" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.OutPutDir == "C:\\temp");
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void OutPutDirArgument_Complex_Returns_OutPutDir()
    {
        var args = new[] { Parameter.OutPutDir.Complex, "C:\\temp" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.OutPutDir == "C:\\temp");
        Assert.Null(sut.Message);
    }
}