using Tiny.Cli;
using Tiny.Cli.Misc;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class ResizeArgumentValidatorTests
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var args = Array.Empty<string>();
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.Null(response.Resize);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var args = new []{ "-unsupported"};
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.Null(response.Resize);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void ResizeArgument_Simple_Returns_Resize()
    {
        var args = new[] { Parameter.Resize.Simple, "1050" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.Resize == 1050);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void ResizeArgument_Complex_Returns_Resize()
    {
        var args = new[] { Parameter.Resize.Complex, "1050" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.Resize == 1050);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void ResizeArgument_Simple_With_No_Size_Returns_Null()
    {
        var args = new[] { Parameter.Resize.Simple };
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.Resize);
        Assert.True(sut.Message is not null);
    }
    
    [Fact]
    public void ResizeArgument_Complex_With_No_Size_Returns_Null()
    {
        var args = new[] { Parameter.Resize.Complex };
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.Resize);
        Assert.True(sut.Message is not null);
    }
    
    [Fact]
    public void ResizeArgument_Simple_With_No_Int_Returns_Null()
    {
        var args = new[] { Parameter.Resize.Simple, "Test" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.Resize);
        Assert.True(sut.Message is not null);
    }
    
    [Fact]
    public void ResizeArgument_Complex_With_No_Int_Returns_Null()
    {
        var args = new[] { Parameter.Resize.Complex, "Test" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.Resize);
        Assert.True(sut.Message is not null);
    }
}