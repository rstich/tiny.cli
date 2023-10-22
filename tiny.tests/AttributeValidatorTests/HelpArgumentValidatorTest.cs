using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class HelpArgumentValidatorTest
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var arguments = Array.Empty<string>();
        var workFlowParams = new WorkFlowParameters();
        var validator = new HelpArgumentValidator();
        
        validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var arguments = new []{ "-unsupported"};
        var workFlowParams = new WorkFlowParameters();
        var validator = new HelpArgumentValidator();
        
        validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(message);
    }
    
    [Fact]
    public void HelpArgument_Simple_Returns_HelpMessage()
    {
        var arguments = new[] { Parameter.Help.Simple };
        var workFlowParams = new WorkFlowParameters();
        var validator = new HelpArgumentValidator();
        
        validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.False(isValid);
        Assert.True(message is not null && message == Parameter.HelpText);
    }
    
    [Fact]
    public void HelpArgument_Complex_Returns_HelpMessage()
    {
        var arguments = new[] { Parameter.Help.Complex };
        var workFlowParams = new WorkFlowParameters();
        var validator = new HelpArgumentValidator();
        
        validator.ValidateArguments(arguments, workFlowParams);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.False(isValid);
        Assert.True(message is not null && message == Parameter.HelpText);
    }
}