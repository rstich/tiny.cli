using Tiny.Cli;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class DirectoryArgumentValidatorTest
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var args = Array.Empty<string>();
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.Null(response.Directory);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var args = new []{ "-unsupported"};
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.Null(response.Directory);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void CurrentDirectoryArgument_Simple_Returns_CurrentDirectory()
    {
        var args = new[] { Parameter.CurrentDirectory.Simple };
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.Directory == Environment.CurrentDirectory);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void CurrentDirectoryArgument_Complex_Returns_CurrentDirectory()
    {
        var args = new[] { Parameter.CurrentDirectory.Complex };
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.Directory == Environment.CurrentDirectory);
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void DirectoryArgument_Simple_Returns_Directory()
    {
        var args = new[] { Parameter.Directory.Simple, "C:\\temp" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.Directory == "C:\\temp");
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void DirectoryArgument_Complex_Returns_Directory()
    {
        var args = new[] { Parameter.Directory.Complex, "C:\\temp" };
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.True(sut.IsValid);
        Assert.True(response.Directory == "C:\\temp");
        Assert.Null(sut.Message);
    }
    
    [Fact]
    public void DirectoryArgument_Simple_MissingDirectoryName_Returns_Null()
    {
        var args = new[] { Parameter.Directory.Simple };
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.Directory);
        Assert.True(sut.Message is not null);
    }
    
    [Fact]
    public void DirectoryArgument_Complex_MissingDirectoryName_Returns_Null()
    {
        var args = new[] { Parameter.Directory.Complex };
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.Directory);
        Assert.True(sut.Message is not null);
    }
    
    [Fact]
    public void ParameterMissMatch_Returns_Null() 
    {
        var args = new[] { Parameter.Directory.Complex, "C:\\temp", Parameter.CurrentDirectory.Simple };
        var workFlowParams = new WorkFlowParameters();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args, workFlowParams);
        
        Assert.False(sut.IsValid);
        Assert.Null(response.Directory);
        Assert.True(sut.Message is not null);
    }
}