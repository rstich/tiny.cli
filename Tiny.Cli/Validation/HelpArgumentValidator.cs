namespace Tiny.Cli.Validation;

public class HelpArgumentValidator : IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        if (arguments.Contains(Parameter.Help.Simple) || arguments.Contains(Parameter.Help.Complex))
        {
            Message = Parameter.HelpText;
        }
        
        IsValid = true;
        return null;
    }
}