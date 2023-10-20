namespace Tiny.Cli.Validation;

public class SingleFileArgumentValidator : IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoFileParameterProvided(arguments)) return null;
        
        if (TooManyFileParametersProvided(arguments)) return null;
        
        int index = GetArgumentIndex(arguments);
        
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
        if (arguments.Contains(Parameter.SingleFile.Simple) && arguments.Contains(Parameter.SingleFile.Complex))
        {
            Message = $"Cannot use both {Parameter.SingleFile.Simple} and {Parameter.SingleFile.Complex}";
            IsValid = false;
            return true;
        }

        if (arguments.Count(s => s.Contains(Parameter.SingleFile.Simple)) <= 1 && arguments.Count(s => s.Contains(Parameter.SingleFile.Complex)) <= 1)
            return false;
        
        Message = "Cannot use file attribute more than once";
        IsValid = false;
        return true;
    }

    private bool NoFileParameterProvided(string[] arguments)
    {
        if (!arguments.Contains(Parameter.SingleFile.Simple) && !arguments.Contains(Parameter.SingleFile.Complex))
        {
            IsValid = true;
            return true;
        }

        return false;
    }

    private int GetArgumentIndex(string[] arguments)
    {
        if (arguments.Contains(Parameter.SingleFile.Simple))
            return Array.IndexOf(arguments, Parameter.SingleFile.Simple);
        
        return Array.IndexOf(arguments, Parameter.SingleFile.Complex);
    }
}