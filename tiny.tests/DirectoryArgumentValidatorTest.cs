using Tiny.Cli.Validation;

namespace tiny.tests;

public class DirectoryArgumentValidatorTest
{
    [Fact]
    public void NoArguments_Returns_Null()
    {
        var args = Array.Empty<string>();
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid());
        Assert.Null(response);
        Assert.Null(sut.GetMessage());
    }
    
    [Fact]
    public void WrongArguments_Returns_Null()
    {
        var args = new []{ "-unsupported"};
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid());
        Assert.Null(response);
        Assert.Null(sut.GetMessage());
    }
    
    [Fact]
    public void CurrentDirectoryArgument_Simple_Returns_CurrentDirectory()
    {
        var args = new[] { "-c" };
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid());
        Assert.True(response is not null && response == Environment.CurrentDirectory);
        Assert.Null(sut.GetMessage());
    }
    
    [Fact]
    public void CurrentDirectoryArgument_Complex_Returns_CurrentDirectory()
    {
        var args = new[] { "--current" };
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid());
        Assert.True(response is not null && response == Environment.CurrentDirectory);
        Assert.Null(sut.GetMessage());
    }
    
    [Fact]
    public void DirectoryArgument_Simple_Returns_Directory()
    {
        var args = new[] { "-d", "C:\\temp" };
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid());
        Assert.True(response is not null && response == "C:\\temp");
        Assert.Null(sut.GetMessage());
    }
    
    [Fact]
    public void DirectoryArgument_Complex_Returns_Directory()
    {
        var args = new[] { "--dir", "C:\\temp" };
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.True(sut.IsValid());
        Assert.True(response is not null && response == "C:\\temp");
        Assert.Null(sut.GetMessage());
    }
    
    [Fact]
    public void DirectoryArgument_Simple_MissingDirectoryName_Returns_Null()
    {
        var args = new[] { "-d" };
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.False(sut.IsValid());
        Assert.Null(response);
        Assert.True(sut.GetMessage() is not null);
    }
    
    [Fact]
    public void DirectoryArgument_Complex_MissingDirectoryName_Returns_Null()
    {
        var args = new[] { "--dir" };
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.False(sut.IsValid());
        Assert.Null(response);
        Assert.True(sut.GetMessage() is not null);
    }
    
    [Fact]
    public void ParameterMissMatch_Returns_Null() 
    {
        var args = new[] { "--dir", "C:\\temp", "-c" };
        var sut = new DirectoryArgumentValidator();
        var response = sut.ValidateArguments(args);
        
        Assert.False(sut.IsValid());
        Assert.Null(response);
        Assert.True(sut.GetMessage() is not null);
    }
}