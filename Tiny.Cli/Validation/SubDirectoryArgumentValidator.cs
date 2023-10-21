namespace Tiny.Cli.Validation;

public class SubDirectoryArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string ValidateArguments(string[] arguments)
    {
        if (NoSubDirectoryParameterProvided(arguments)) return SearchOption.TopDirectoryOnly.ToString();
        if (TooManySubDirectoryParametersProvided(arguments)) return SearchOption.TopDirectoryOnly.ToString();

        IsValid = true;
        return SearchOption.AllDirectories.ToString();
    }

    private bool NoSubDirectoryParameterProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.SubDirectory.Simple, Parameter.SubDirectory.Complex)) return false;
        IsValid = true;
        return true;

    }
    
    private bool TooManySubDirectoryParametersProvided(string[] arguments)
    {
        if (TooManyValidatorArgumentsProvided(arguments, Parameter.SubDirectory.Simple, Parameter.SubDirectory.Complex))
        {
            IsValid = false;
            Message = "Too many subdirectory parameters provided";
            return true;
        }

        if (BothValidatorArgumentsProvided(arguments, Parameter.SubDirectory.Simple, Parameter.SubDirectory.Complex))
        {
            IsValid = false;
            Message = $"Cannot use both {Parameter.SubDirectory.Simple} and {Parameter.SubDirectory.Complex}";
            return true;
        }

        return false;
    }
}