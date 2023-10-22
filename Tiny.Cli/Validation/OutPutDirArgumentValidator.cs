namespace Tiny.Cli.Validation;

public class OutPutDirArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        if (NoArgumentProvided(arguments)) return parameters;
        if (TooManyArgumentsProvided(arguments)) return parameters;
        
        var index = GetArgumentIndex(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex);
        
        if (NoFileNameProvided(arguments, index)) return parameters;
        
        IsValid = true;
        parameters.OutPutDir = arguments[index + 1];
        return parameters;
    }

    private bool TooManyArgumentsProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex))
        {
            IsValid = false;
            Message = $"Cannot use both {Parameter.OutPutDir.Simple} and {Parameter.OutPutDir.Complex}";
            return true;
        }

        if (!TooManyValidatorArgumentsProvided(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex))
            return false;
        
        IsValid = false;
        Message = "Too many output directory parameters provided";
        return true;
    }

    private bool NoArgumentProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex)) return false;
        
        IsValid = true;
        return true;
    }
    
    private bool NoFileNameProvided(string[] arguments, int index)
    {
        if (index + 1 < arguments.Length && !arguments[index + 1].StartsWith("-")) return false;
        Message = $"Missing file name for parameter {arguments[index]}";
        IsValid = false;
        return true;

    }
}