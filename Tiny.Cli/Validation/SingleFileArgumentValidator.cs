namespace Tiny.Cli.Validation;

public class SingleFileArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoFileParameterProvided(arguments)) return null;
        
        if (TooManyFileParametersProvided(arguments)) return null;

        int index = GetArgumentIndex(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex);
        
        if (NoFileNameProvided(arguments, index)) return null;
        
        IsValid = true;
        return arguments[index + 1];
    }

    private bool NoFileNameProvided(string[] arguments, int index)
    {
        if (index + 1 >= arguments.Length || arguments[index + 1].StartsWith("-"))
        {
            Message = "Missing file name";
            IsValid = false;
            return true;
        }

        return false;
    }

    private bool TooManyFileParametersProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex))
        {
            Message = $"Cannot use both {Parameter.SingleFile.Simple} and {Parameter.SingleFile.Complex}";
            IsValid = false;
            return true;
        }
        
        if (TooManyValidatorArgumentsProvided(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex))
        {
            Message = "Too many file parameters provided";
            IsValid = false;
            return true;
        }

        return false;
    }

    private bool NoFileParameterProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex)) return false;
        
        IsValid = true;
        return true;
    }
}