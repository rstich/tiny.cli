using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public interface IArgumentValidator
{
    bool IsValid { get; }
    string? Message { get; }
    
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters);
}