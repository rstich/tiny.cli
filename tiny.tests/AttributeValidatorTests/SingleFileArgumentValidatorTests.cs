using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class SingleFileArgumentValidatorTests
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var arguments = Array.Empty<string>();
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(response.FilePath);
        Assert.Null(message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var arguments = new []{ "-unsupported"};
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(response.FilePath);
        Assert.Null(message);
    }
    
    [Fact]
    public void SingleFileArgument_Simple_Returns_SingleFile()
    {
        string fileName = "test.jpg";
        var arguments = new[] { Parameter.SingleFile.Simple, fileName };
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.True(response.FilePath == fileName);
        Assert.Null(message);
    }
    
    [Fact]
    public void SingleFileArgument_Complex_Returns_SingleFile()
    {
        string fileName = "test.jpg";
        var arguments = new[] { Parameter.SingleFile.Complex, fileName };
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.True(response.FilePath == fileName);
        Assert.Null(message);
    }
    
    [Fact]
    public void SingleFileArgument_Simple_MissingFileName_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Simple };
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.False(isValid);
        Assert.Null(response.FilePath);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void SingleFileArgument_Complex_MissingFileName_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Complex };
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.False(isValid);
        Assert.Null(response.FilePath);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void ToManyFileArguments_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Complex, "test.jpg", Parameter.SingleFile.Simple, "test2.jpg" };
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.False(isValid);
        Assert.Null(response.FilePath);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void DoubleFileArguments_Simple_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Simple, "test.jpg", Parameter.SingleFile.Simple, "test2.jpg" };
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.False(isValid);
        Assert.Null(response.FilePath);
        Assert.True(message is not null);
    }
    
    [Fact]
    public void DoubleFileArguments_Complex_Returns_Null()
    {
        var arguments = new[] { Parameter.SingleFile.Complex, "test.jpg", Parameter.SingleFile.Complex, "test2.jpg" };
        var workFlowParams = new WorkFlowParameters();
        var validator = new SingleFileArgumentValidator();
        
        var response = validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.False(isValid);
        Assert.Null(response.FilePath);
        Assert.True(message is not null);
    }
}