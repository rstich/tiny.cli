using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class SubDirectoryArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        if (TooManySubDirectoryParametersProvided(arguments)) return parameters;
        
        IsValid = true;
        parameters.SearchOption = SearchOption.AllDirectories;
        
        if (NoSubDirectoryParameterProvided(arguments)) parameters.SearchOption = SearchOption.TopDirectoryOnly;
        
        return parameters;
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