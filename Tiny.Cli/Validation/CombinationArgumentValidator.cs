using Tiny.Cli.Misc;

namespace Tiny.Cli.Validation;

public class CombinationArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; }
    public string? Message { get; }
    public WorkFlowParameters ValidateArguments(string[] arguments, WorkFlowParameters parameters)
    {
        // validate combination, there has to be a decicision if single file or directory but not both
        throw new NotImplementedException();
    }
}