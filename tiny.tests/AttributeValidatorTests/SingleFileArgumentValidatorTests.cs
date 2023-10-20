using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class SingleFileArgumentValidatorTests
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var arguments = Array.Empty<string>();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.True(isValid);
        Assert.Null(response);
        Assert.Null(message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var arguments = new []{ "-unsupported"};
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.True(isValid);
        Assert.Null(response);
        Assert.Null(message);
    }
    
    [Fact]
    public void SingleFileArgument_Simple_Returns_SingleFile()
    {
        string fileName = "test.jpg";
        var arguments = new[] { Parameter.SingleFile.Simple, fileName };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.True(isValid);
        Assert.True(response is not null && response == fileName);
        Assert.Null(message);
    }
    
    [Fact]
    public void SingleFileArgument_Complex_Returns_SingleFile()
    {
        string fileName = "test.jpg";
        var arguments = new[] { Parameter.SingleFile.Complex, fileName };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.True(isValid);
        Assert.True(response is not null && response == fileName);
        Assert.Null(message);
    }
    
    [Fact]
    public void SingleFileArgument_Simple_MissingFileName_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Simple };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.False(isValid);
        Assert.Null(response);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void SingleFileArgument_Complex_MissingFileName_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Complex };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.False(isValid);
        Assert.Null(response);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void ToManyFileArguments_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Complex, "test.jpg", Parameter.SingleFile.Simple, "test2.jpg" };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.False(isValid);
        Assert.Null(response);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void DoubleFileArguments_Simple_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Simple, "test.jpg", Parameter.SingleFile.Simple, "test2.jpg" };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.False(isValid);
        Assert.Null(response);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void DoubleFileArguments_Complex_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Complex, "test.jpg", Parameter.SingleFile.Complex, "test2.jpg" };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.False(isValid);
        Assert.Null(response);
        Assert.True(message is not null);
    }
}