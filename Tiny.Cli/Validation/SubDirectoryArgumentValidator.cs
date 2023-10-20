namespace Tiny.Cli.Validation;

public class SubDirectoryArgumentValidator : IArgumentValidator
{
    private bool _isValid;
    private string? _message;
    
    public bool IsValid()
    {
        return _isValid;
    }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoSubDirectoryParameterProvided(arguments)) return SearchOption.TopDirectoryOnly.ToString();
        if (TooManySubDirectoryParametersProvided(arguments)) return SearchOption.TopDirectoryOnly.ToString();

        _isValid = true;
        return SearchOption.AllDirectories.ToString();
    }
    
    public string? GetMessage()
    {
        return _message;
    }

    private bool NoSubDirectoryParameterProvided(string[] arguments)
    {
        if (!arguments.Contains(Parameter.SubDirectory.Simple) && !arguments.Contains(Parameter.SubDirectory.Complex))
        {
            _isValid = true;
            return true;
        }

        return false;
    }
    
    private bool TooManySubDirectoryParametersProvided(string[] arguments)
    {
        if (arguments.Contains(Parameter.SubDirectory.Simple) && arguments.Contains(Parameter.SubDirectory.Complex))
        {
            _message = $"Cannot use both {Parameter.SubDirectory.Simple} and {Parameter.SubDirectory.Complex}";
            _isValid = false;
            return true;
        }

        if (arguments.Count(s => s.Contains(Parameter.SubDirectory.Simple)) <= 1 && arguments.Count(s => s.Contains(Parameter.SubDirectory.Complex)) <= 1)
            return false;
        
        _message = "Cannot use sub directory attribute more than once";
        _isValid = false;
        return true;
    }
}