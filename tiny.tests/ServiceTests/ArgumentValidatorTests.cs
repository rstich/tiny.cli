using NSubstitute;
using Tiny.Cli.Misc;
using Tiny.Cli.Service;
using Tiny.Cli.Validation;

namespace tiny.tests.ServiceTests;

public class ArgumentValidatorTests
{
    private IEnumerable<IArgumentValidator> CreateCollectionOfValidators(int numberOfValidators, bool invalidValidators = false, int factor = 2)
    {
        var retVal = new List<IArgumentValidator>();
        
        for (int i = 0; i < numberOfValidators; i++)
        {
            var current = Substitute.For<IArgumentValidator>();
            current.IsValid.Returns(true);
            if (invalidValidators && i % factor == 0)
            {
                current.Message.Returns("Failure");
                current.IsValid.Returns(false);
            }
            
            retVal.Add(current);
        }

        return retVal;
    }
    
    [Fact]
    public void NoArguments_ThrowsException()
    {
        var testData = CreateCollectionOfValidators(10);
        var sut = new ArgumentValidationService(testData);
        var arguments = Array.Empty<string>();
        
        Assert.Throws<NoArgumentsProvidedException>(() => sut.ValidateArgumentsAndParseParameters(arguments));
    }
    
    [Fact]
    public void InValidValidator_ThrowsException()
    {
        var testData = CreateCollectionOfValidators(10, true, 2);
        var sut = new ArgumentValidationService(testData);
        var arguments = new []{Parameter.Help.Simple};
        
        Assert.Throws<InvalidParametersException>(() => sut.ValidateArgumentsAndParseParameters(arguments));
    }
    
    [Fact]
    public void ValidValidator_ReturnsWorkFlowParameters()
    {
        var testData = CreateCollectionOfValidators(10);
        var sut = new ArgumentValidationService(testData);
        var arguments = new []{Parameter.Help.Simple};
        var response = sut.ValidateArgumentsAndParseParameters(arguments);

        Assert.NotNull(response);
    }
}