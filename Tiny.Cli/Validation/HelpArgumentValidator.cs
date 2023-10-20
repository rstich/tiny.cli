namespace Tiny.Cli.Validation;

public class HelpArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.Help.Simple, Parameter.Help.Complex))
        {
            Message = Parameter.HelpText;
        }
        
        IsValid = true;
        return null;
    }
}