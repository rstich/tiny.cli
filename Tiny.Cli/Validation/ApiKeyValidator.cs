using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class ApiKeyValidator : IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        // concept for mocking this. Currently only solution is to write a wrapper class and inject it
        var tinyKey = Environment.GetEnvironmentVariable("TINY_KEY");

        if (tinyKey is null)
        {
            Message = @"Please set the TINY_KEY environment variable by typing:
                        set TINY_KEY=your_api_key";
            
            IsValid = false;
            return parameters;
        }

        parameters.ApiKey = tinyKey; // Your API key4
        
        IsValid = true;
        return parameters;
    }
}