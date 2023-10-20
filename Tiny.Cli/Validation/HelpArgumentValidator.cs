namespace Tiny.Cli.Validation;

public class HelpArgumentValidator : IArgumentValidator
{
    private bool _isValid = true;
    private string? _returnMessage;
    
    public bool IsValid()
    {
        return _isValid;
    }

    public string? ValidateArguments(string[] arguments)
    {
        if (arguments.Contains(Parameter.Help.Simple) || arguments.Contains(Parameter.Help.Complex))
        {
            _returnMessage = Parameter.HelpText;
        }
        
        _isValid = true;
        return null;
    }

    public string? GetMessage()
    {
        return _returnMessage; 
    }
}