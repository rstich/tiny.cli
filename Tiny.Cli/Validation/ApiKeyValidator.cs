using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class ApiKeyValidator : IArgumentValidator
{
    public bool IsValid { get; }
    public string? Message { get; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        // place validation for the environment variable here
        throw new NotImplementedException();
    }
}