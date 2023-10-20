namespace Tiny.Cli.Validation;

public class SingleFileArgumentValidator : IArgumentValidator
{
    private string? _message;
    private bool _isValid;
    
    public bool IsValid()
    {
        return _isValid;
    }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoFileParameterProvided(arguments)) return null;
        
        if (TooManyFileParametersProvided(arguments)) return null;
        
        int index = GetArgumentIndex(arguments);
        
        if (NoFileNameProvided(arguments, index)) return null;
        
        _isValid = true;
        return arguments[index + 1];
    }

    private bool NoFileNameProvided(string[] arguments, int index)
    {
        if (index + 1 >= arguments.Length || arguments[index + 1].StartsWith("-"))
        {
            _message = "Missing file name";
            _isValid = false;
            return true;
        }

        return false;
    }

    private bool TooManyFileParametersProvided(string[] arguments)
    {
        if (arguments.Contains(Parameter.SingleFile.Simple) && arguments.Contains(Parameter.SingleFile.Complex))
        {
            _message = $"Cannot use both {Parameter.SingleFile.Simple} and {Parameter.SingleFile.Complex}";
            _isValid = false;
            return true;
        }

        if (arguments.Count(s => s.Contains(Parameter.SingleFile.Simple)) <= 1 && arguments.Count(s => s.Contains(Parameter.SingleFile.Complex)) <= 1)
            return false;
        
        _message = "Cannot use file attribute more than once";
        _isValid = false;
        return true;
    }

    private bool NoFileParameterProvided(string[] arguments)
    {
        if (!arguments.Contains(Parameter.SingleFile.Simple) && !arguments.Contains(Parameter.SingleFile.Complex))
        {
            _isValid = true;
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

    public string? GetMessage()
    {
        return _message;
    }
}