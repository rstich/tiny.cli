using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class SingleFileArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        if (NoFileParameterProvided(arguments)) return parameters;
        
        if (TooManyFileParametersProvided(arguments)) return parameters;

        var index = GetArgumentIndex(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex);
        
        if (NoFileNameProvided(arguments, index)) return parameters;
        
        IsValid = true;
        parameters.FilePath = arguments[index + 1];
        return parameters;
    }

    private bool NoFileNameProvided(string[] arguments, int index)
    {
        if (index + 1 < arguments.Length && !arguments[index + 1].StartsWith("-")) return false;
        
        Message = $"Missing file name for parameter {arguments[index]}";
        IsValid = false;
        return true;

    }

    private bool TooManyFileParametersProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex))
        {
            Message = $"Cannot use both {Parameter.SingleFile.Simple} and {Parameter.SingleFile.Complex}";
            IsValid = false;
            return true;
        }

        if (!TooManyValidatorArgumentsProvided(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex))
            return false;
        
        Message = "Too many file parameters provided";
        IsValid = false;
        return true;
    }

    private bool NoFileParameterProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.SingleFile.Simple, Parameter.SingleFile.Complex)) return false;
        
        IsValid = true;
        return true;
    }
}