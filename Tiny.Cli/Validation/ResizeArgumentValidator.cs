using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class ResizeArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set;  }
    public string? Message { get; private set; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        if (NoArgumentProvided(arguments)) return parameters;
        if (TooManyArgumentsProvided(arguments)) return parameters;
        
        var index = GetArgumentIndex(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex);
        
        if (NoSizeParameterProvided(arguments, index)) return parameters;
        
        ParseResizeParameter(arguments, parameters, index);

        return parameters;
    }

    private bool NoSizeParameterProvided(string[] arguments, int index)
    {
        if (index + 1 < arguments.Length && !arguments[index + 1].StartsWith("-")) return false;
        Message = "Missing Size for resize parameter";
        IsValid = false;
        return true;

    }

    private bool TooManyArgumentsProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex))
        {
            IsValid = false;
            Message = $"Cannot use both {Parameter.Resize.Simple} and {Parameter.Resize.Complex}";
            return true;
        }

        if (!TooManyValidatorArgumentsProvided(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex))
            return false;
        
        IsValid = false;
        Message = "Too many resize parameters provided";
        return true;
    }

    private bool NoArgumentProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.Resize.Simple, Parameter.Resize.Complex)) return false;
        
        IsValid = true;
        return true;
    }
    
    private void ParseResizeParameter(string[] arguments, WorkFlowParameters parameters, int index)
    {
        IsValid = int.TryParse(arguments[index + 1], out var size);

        if (!IsValid)
        {
            Message = $"Invalid size provided for {Parameter.Resize.Simple} or {Parameter.Resize.Complex}";
            return;
        }
        
        parameters.Resize = size;
    }
}