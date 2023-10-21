using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class ResizeArgumentValidatorTests
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var args = Array.Empty<string>();
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.Null(response);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var args = new []{ "-unsupported"};
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.Null(response);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void ResizeArgument_Simple_Returns_Resize()
    {
        var args = new[] { Parameter.Resize.Simple, "1050" };
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response is not null && response == "1050");
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void ResizeArgument_Complex_Returns_Resize()
    {
        var args = new[] { Parameter.Resize.Complex, "1050" };
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response is not null && response == "1050");
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void ResizeArgument_Simple_With_No_Size_Returns_Null()
    {
        var args = new[] { Parameter.Resize.Simple };
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.False(sut.IsValid);
        Assert.Null(response);
        Assert.True(sut.Message is not null);
    }
    
    [Fact]
    public void ResizeArgument_Complex_With_No_Size_Returns_Null()
    {
        var args = new[] { Parameter.Resize.Complex };
        var sut = new ResizeArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.False(sut.IsValid);
        Assert.Null(response);
        Assert.True(sut.Message is not null);
    }
}