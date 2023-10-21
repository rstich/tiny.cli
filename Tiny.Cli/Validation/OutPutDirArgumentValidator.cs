namespace Tiny.Cli.Validation;

public class OutPutDirArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoArgumentProvided(arguments)) return null;
        if (TooManyArgumentsProvided(arguments)) return null;
        
        int index = GetArgumentIndex(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex);
        
        if (NoFileNameProvided(arguments, index)) return null;
        
        IsValid = true;
        return arguments[index + 1];
    }

    private bool TooManyArgumentsProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex))
        {
            IsValid = false;
            Message = $"Cannot use both {Parameter.OutPutDir.Simple} and {Parameter.OutPutDir.Complex}";
            return true;
        }
        
        if (TooManyValidatorArgumentsProvided(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex))
        {
            IsValid = false;
            Message = "Too many output directory parameters provided";
            return true;
        }
        
        return false;
    }

    private bool NoArgumentProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex)) return false;
        
        IsValid = true;
        return true;
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
}