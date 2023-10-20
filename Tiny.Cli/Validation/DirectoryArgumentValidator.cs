namespace Tiny.Cli.Validation;

public class DirectoryArgumentValidator : IArgumentValidator
{
    private bool _isValid;
    private string? _message;
    public bool IsValid()
    {
        return _isValid;
    }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoDirectoryArgumentProvided(arguments)) return null;
        if (TooManyDirectoryParametersProvided(arguments)) return null;
        if (TooManyCurrentDirectoryParametersProvided(arguments)) return null;
        if (HasParameterMissMatch(arguments)) return null;
        
        if (CurrentDirectoryIsProvided(arguments)) return Environment.CurrentDirectory;
        
        if (NoFileNameProvided(arguments)) return null;
        
        _isValid = true;
        return GetDirectory(arguments);
    }

    private bool HasParameterMissMatch(string[] arguments)
    {
        if (CheckParameterCombination(arguments, Parameter.Directory.Simple, Parameter.CurrentDirectory.Simple)) return true;
        if (CheckParameterCombination(arguments, Parameter.Directory.Simple, Parameter.CurrentDirectory.Complex)) return true;
        if (CheckParameterCombination(arguments, Parameter.Directory.Complex, Parameter.CurrentDirectory.Simple)) return true;
        if (CheckParameterCombination(arguments, Parameter.Directory.Complex, Parameter.CurrentDirectory.Complex)) return true;
        return false; 
    }

    private bool NoFileNameProvided(string[] arguments)
    {
        if (GetDirectory(arguments) is null)
        {
            _message = "Missing directory name";
            _isValid = false;
            return true;
        }
        return false;
    }

    private string? GetDirectory(string[] arguments)
    {
        var index = Array.IndexOf(arguments, Parameter.Directory.Simple);
        if (index == -1) index = Array.IndexOf(arguments, Parameter.Directory.Complex);
        
        if (index + 1 >= arguments.Length || arguments[index + 1].StartsWith("-"))
            return null;
        
        return arguments[index + 1];
    }

    private bool TooManyCurrentDirectoryParametersProvided(string[] arguments)
    {
        return CheckIfCombinationIsDoubled(arguments, Parameter.CurrentDirectory.Simple, Parameter.CurrentDirectory.Complex);
    }
    
    private bool TooManyDirectoryParametersProvided(string[] arguments)
    {
        return CheckIfCombinationIsDoubled(arguments, Parameter.Directory.Simple, Parameter.Directory.Complex); 
    }

    private bool CheckIfCombinationIsDoubled(string[] arguments, string simple, string complex)
    {
        if (CheckParameterCombination(arguments, simple, complex)) return true;

        if (arguments.Count(s => s.Contains(simple)) <= 1 && arguments.Count(s => s.Contains(complex)) <= 1)
            return false;
        
        _message = $"Cannot use {simple} or {complex} attribute more than once";
        _isValid = false;
        return true;
    }

    private bool CheckParameterCombination(string[] arguments, string firstParam, string secondParam)
    {
        if (arguments.Contains(firstParam) && arguments.Contains(secondParam))
        {
            _message = $"Cannot use both {firstParam} and {secondParam}";
            _isValid = false;
            return true;
        }

        return false;
    }

    private bool CurrentDirectoryIsProvided(string[] arguments)
    {
        _isValid = arguments.Contains(Parameter.CurrentDirectory.Simple) || arguments.Contains(Parameter.CurrentDirectory.Complex);
        return _isValid;
    }

    private bool NoDirectoryArgumentProvided(string[] arguments)
    {
        if (!arguments.Contains(Parameter.Directory.Simple) && !arguments.Contains(Parameter.Directory.Complex) && !arguments.Contains(Parameter.CurrentDirectory.Simple) &&
            !arguments.Contains(Parameter.CurrentDirectory.Complex))
        {
            _isValid = true;
            return true;
        }

        return false;
    }

    public string? GetMessage()
    {
        return _message;
    }
}