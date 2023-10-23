using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class CombinationOfArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        var singleFile = ContainsValidatorArgument(arguments, Parameter.SingleFile.Complex, Parameter.SingleFile.Simple);
        var directoryProvided = DirectoryProvided(arguments);

        if (!singleFile || !directoryProvided)
        {
            IsValid = true;
            return parameters;
        }
        
        IsValid = false;
        Message = "There cant be both parameters for single file and directory";
        return parameters;
    }

    private bool DirectoryProvided(string[] arguments)
    {
        var directory = ContainsValidatorArgument(arguments, Parameter.Directory.Complex, Parameter.Directory.Simple);
        var currentDir =
            ContainsValidatorArgument(arguments, Parameter.CurrentDirectory.Complex, Parameter.CurrentDirectory.Simple);
        var subDir = ContainsValidatorArgument(arguments, Parameter.SubDirectory.Complex, Parameter.SubDirectory.Simple);

        var directoryProvided = directory || currentDir || subDir;
        return directoryProvided;
    }
}