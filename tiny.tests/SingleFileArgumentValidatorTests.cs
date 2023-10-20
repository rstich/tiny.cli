using Tiny.Cli.Validation;

namespace tiny.tests;

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
        var arguments = new[] { "-f", fileName };
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
        var arguments = new[] { "--file", fileName };
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
        var arguments = new[] { "-f" };
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
        var arguments = new[] { "--file" };
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
        var arguments = new[] { "--file", "test.jpg", "-f", "test2.jpg" };
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
        var arguments = new[] { "-f", "test.jpg", "-f", "test2.jpg" };
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
        var arguments = new[] { "--file", "test.jpg", "--file", "test2.jpg" };
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid();
        var message = validator.GetMessage();
        
        Assert.False(isValid);
        Assert.Null(response);
        Assert.True(message is not null);
    }
}