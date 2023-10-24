using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class ApiKeyValidator : IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }
    
    private readonly EnvironmentWrapper _environmentWrapper;
    public ApiKeyValidator(EnvironmentWrapper environmentWrapper)
    {
        _environmentWrapper = environmentWrapper;
    }
    
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        // Currently only solution is to write a wrapper class and inject it to be able to mock this
        var tinyKey = _environmentWrapper.GetEnvironmentVariable();

        if (tinyKey is null)
        {
            Message = @"Please set the TINY_KEY environment variable by typing:
                        set TINY_KEY=your_api_key";
            
            IsValid = false;
            return parameters;
        }

        parameters.ApiKey = tinyKey; // Your API key
        
        IsValid = true;
        return parameters;
    }
}