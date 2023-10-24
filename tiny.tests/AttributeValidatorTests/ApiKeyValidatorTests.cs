using NSubstitute;
using NSubstitute.Extensions;
using NSubstitute.ReturnsExtensions;
using Tiny.Cli.Misc;
using Tiny.Cli.Validation;

namespace tiny.tests.AttributeValidatorTests;

public class ApiKeyValidatorTests
{
    private readonly EnvironmentWrapper _envWrapper = Substitute.For<EnvironmentWrapper>();
    
    [Fact]
    public void ReturnsApiKey_IfEnvVariableIsSet()
    {
        const string apiKey = "Test Value";
        _envWrapper.GetEnvironmentVariable().Returns(apiKey);
        ApiKeyValidator _sut = new ApiKeyValidator(_envWrapper);
        
        WorkFlowParameters parameters = new WorkFlowParameters();
        var arguments = Array.Empty<string>();

        var response = _sut.ValidateArguments(arguments, parameters);
        
        Assert.True(_sut.IsValid);
        Assert.True(_sut.Message is null);
        Assert.True(response.ApiKey == apiKey);
    }

    [Fact]
    public void ReturnsNoKey_IfNoEnvVariable()
    {
        _envWrapper.GetEnvironmentVariable().ReturnsNull();
        ApiKeyValidator _sut = new ApiKeyValidator(_envWrapper);
        
        WorkFlowParameters parameters = new WorkFlowParameters();
        var arguments = Array.Empty<string>();

        var response = _sut.ValidateArguments(arguments, parameters);
        
        Assert.False(_sut.IsValid);
        Assert.True(response.ApiKey == string.Empty);
        Assert.True(_sut.Message is not null);
    }
}