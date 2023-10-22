using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class HelpArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        IsValid = true;
        if (!ContainsValidatorArgument(arguments, Parameter.Help.Simple, Parameter.Help.Complex)) return parameters;
        Message = Parameter.HelpText;
        IsValid = false;
        
        return parameters;
    }
}