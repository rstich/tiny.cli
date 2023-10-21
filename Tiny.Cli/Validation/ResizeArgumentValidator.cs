namespace Tiny.Cli.Validation;

public class ResizeArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set;  }
    public string? Message { get; private set; }
    public string? ValidateArguments(string[] arguments)
    {
        if (NoArgumentProvided(arguments)) return null;
        if (TooManyArgumentsProvided(arguments)) return null;
        
        int index = GetArgumentIndex(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex);
        
        if (NoSizeParameterProvided(arguments, index)) return null;
        
        IsValid = true;
        return arguments[index + 1];
    }

    private bool NoSizeParameterProvided(string[] arguments, int index)
    {
        if (index + 1 >= arguments.Length || arguments[index + 1].StartsWith("-"))
        {
            Message = "Missing Size for resize parameter";
            IsValid = false;
            return true;
        }

        return false;
    }

    private bool TooManyArgumentsProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex))
        {
            IsValid = false;
            Message = $"Cannot use both {Parameter.Resize.Simple} and {Parameter.Resize.Complex}";
            return true;
        }
        
        if (TooManyValidatorArgumentsProvided(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex))
        {
            IsValid = false;
            Message = "Too many resize parameters provided";
            return true;
        }
        
        return false;
    }

    private bool NoArgumentProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex)) return false;
        
        IsValid = true;
        return true;
    }
}