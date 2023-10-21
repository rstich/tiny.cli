namespace Tiny.Cli.Validation;

public class DirectoryArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }

    public string? Message { get; private set;}

    public string? ValidateArguments(string[] arguments)
    {
        if (NoDirectoryArgumentProvided(arguments)) return null;
        if (TooManyDirectoryParametersProvided(arguments)) return null;
        if (TooManyCurrentDirectoryParametersProvided(arguments)) return null;
        if (HasParameterMissMatch(arguments))
        {
            IsValid = false;
            Message = "Parameter mismatch";
            return null;
        }

        if (CurrentDirectoryIsProvided(arguments)) return Environment.CurrentDirectory;
        
        if (NoFileNameProvided(arguments)) return null;
        
        IsValid = true;
        return GetDirectory(arguments);
    }
    
    private bool NoDirectoryArgumentProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.Directory.Simple, Parameter.Directory.Complex)
            || ContainsValidatorArgument(arguments, Parameter.CurrentDirectory.Simple, Parameter.CurrentDirectory.Complex)) return false;
        IsValid = true;
        return true;
    }
    
    private bool TooManyDirectoryParametersProvided(string[] arguments)
    {
        return BothValidatorArgumentsProvided(arguments, Parameter.Directory.Simple, Parameter.Directory.Complex);
    }
    
    private bool TooManyCurrentDirectoryParametersProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.CurrentDirectory.Simple, Parameter.CurrentDirectory.Complex))
        {
            IsValid = false;
            Message = $"Cannot use both {Parameter.CurrentDirectory.Simple} and {Parameter.CurrentDirectory.Complex}";
            return true;    
        }

        if (!TooManyValidatorArgumentsProvided(arguments, Parameter.CurrentDirectory.Simple,
                Parameter.CurrentDirectory.Complex)) return false;
        IsValid = false;
        Message = "Too many current directory parameters provided";
        return true;

    }

    private bool HasParameterMissMatch(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.Directory.Simple, Parameter.CurrentDirectory.Simple)) return true;
        if (BothValidatorArgumentsProvided(arguments, Parameter.Directory.Simple, Parameter.CurrentDirectory.Complex)) return true;
        if (BothValidatorArgumentsProvided(arguments, Parameter.Directory.Complex, Parameter.CurrentDirectory.Simple)) return true;
        if (BothValidatorArgumentsProvided(arguments, Parameter.Directory.Complex, Parameter.CurrentDirectory.Complex)) return true;
        return false; 
    }

    private bool NoFileNameProvided(string[] arguments)
    {
        if (GetDirectory(arguments) is null)
        {
            Message = $"Missing directory name for parameter {Parameter.Directory.Simple}";
            IsValid = false;
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

    private bool CurrentDirectoryIsProvided(string[] arguments)
    {
        IsValid = arguments.Contains(Parameter.CurrentDirectory.Simple) || arguments.Contains(Parameter.CurrentDirectory.Complex);
        return IsValid;
    }

    
}