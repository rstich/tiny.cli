using Tiny.Cli.Misc;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class CombinationOfArgumentValidatorTests
{
    [Fact]
    public void IsInvalid_IfBothArgumentsAreProvided_Simple()
    {
        var validator = new CombinationOfArgumentValidator();
        var parameters = new WorkFlowParameters
        {
            Directory = "C:\\",
            FilePath = "C:\\file.txt"
        };
        var arguments = new[] { Parameter.Directory.Simple, "C:\\", Parameter.SingleFile.Simple, "C:\\file.txt" };
        validator.ValidateArguments(arguments, parameters);
        
        Assert.False(validator.IsValid);
    }
    
    [Fact]
    public void IsInvalid_IfBothArgumentsAreProvided_Complex()
    {
        var validator = new CombinationOfArgumentValidator();
        var parameters = new WorkFlowParameters
        {
            Directory = "C:\\",
            FilePath = "C:\\file.txt"
        };
        var arguments = new[] { Parameter.Directory.Complex, "C:\\", Parameter.SingleFile.Complex, "C:\\file.txt" };
        validator.ValidateArguments(arguments, parameters);
        
        Assert.False(validator.IsValid);
    }
    
    [Fact]
    public void IsValid_IfOnlyDirectoryArgumentsAreProvided_Simple()
    {
        var validator = new CombinationOfArgumentValidator();
        var parameters = new WorkFlowParameters
        {
            Directory = "C:\\",
            FilePath = "C:\\file.txt"
        };
        var arguments = new[] { Parameter.Directory.Simple, "C:\\" };
        validator.ValidateArguments(arguments, parameters);
        
        Assert.True(validator.IsValid);
    }
    
    [Fact]
    public void IsValid_IfOnlyDirectoryArgumentsAreProvided_Complex()
    {
        var validator = new CombinationOfArgumentValidator();
        var parameters = new WorkFlowParameters
        {
            Directory = "C:\\",
            FilePath = "C:\\file.txt"
        };
        var arguments = new[] { Parameter.Directory.Complex, "C:\\" };
        validator.ValidateArguments(arguments, parameters);
        
        Assert.True(validator.IsValid);
    }
    
    [Fact]
    public void IsValid_IfOnlySingleFileArgumentsAreProvided_Simple()
    {
        var validator = new CombinationOfArgumentValidator();
        var parameters = new WorkFlowParameters
        {
            Directory = "C:\\",
            FilePath = "C:\\file.txt"
        };
        var arguments = new[] { Parameter.Directory.Simple, "C:\\" };
        validator.ValidateArguments(arguments, parameters);
        
        Assert.True(validator.IsValid);
    }
    
    [Fact]
    public void IsValid_IfOnlySingleFileArgumentsAreProvided_Complex()
    {
        var validator = new CombinationOfArgumentValidator();
        var parameters = new WorkFlowParameters
        {
            Directory = "C:\\",
            FilePath = "C:\\file.txt"
        };
        var arguments = new[] { Parameter.Directory.Complex, "C:\\" };
        validator.ValidateArguments(arguments, parameters);
        
        Assert.True(validator.IsValid);
    }
}