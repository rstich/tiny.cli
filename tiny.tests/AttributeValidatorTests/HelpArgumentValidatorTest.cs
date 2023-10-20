﻿using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class HelpArgumentValidatorTest
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var arguments = Array.Empty<string>();
        var validator = new HelpArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(response);
        Assert.Null(message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var arguments = new []{ "-unsupported"};
        var validator = new HelpArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(response);
        Assert.Null(message);
    }
    
    [Fact]
    public void HelpArgument_Simple_Returns_HelpMessage()
    {
        var arguments = new[] { Parameter.Help.Simple };
        var validator = new HelpArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(response);
        Assert.True(message is not null && message == Parameter.HelpText);
    }
    
    [Fact]
    public void HelpArgument_Complex_Returns_HelpMessage()
    {
        var arguments = new[] { Parameter.Help.Complex };
        var validator = new HelpArgumentValidator();
        
        var response = validator.ValidateArguments(arguments);
        var isValid = validator.IsValid;
        var message = validator.Message;
        
        Assert.True(isValid);
        Assert.Null(response);
        Assert.True(message is not null && message == Parameter.HelpText);
    }
    
    
}