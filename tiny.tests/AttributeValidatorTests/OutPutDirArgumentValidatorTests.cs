using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class OutPutDirArgumentValidatorTests
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var args = Array.Empty<string>();
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.Null(response);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var args = new []{ "-unsupported"};
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.Null(response);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void OutPutDirArgument_Simple_Returns_OutPutDir()
    {
        var args = new[] { Parameter.OutPutDir.Simple, "C:\\temp" };
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response is not null && response == "C:\\temp");
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void OutPutDirArgument_Complex_Returns_OutPutDir()
    {
        var args = new[] { Parameter.OutPutDir.Complex, "C:\\temp" };
        var sut = new OutPutDirArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid);
        Assert.True(response is not null && response == "C:\\temp");
        Assert.Null(sut.Message);
    }
}