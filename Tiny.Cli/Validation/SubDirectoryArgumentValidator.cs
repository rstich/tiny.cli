namespace Tiny.Cli.Validation;

public class SubDirectoryArgumentValidator : IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoSubDirectoryParameterProvided(arguments)) return SearchOption.TopDirectoryOnly.ToString();
        if (TooManySubDirectoryParametersProvided(arguments)) return SearchOption.TopDirectoryOnly.ToString();

        IsValid = true;
        return SearchOption.AllDirectories.ToString();
    }

    private bool NoSubDirectoryParameterProvided(string[] arguments)
    {
        if (!arguments.Contains(Parameter.SubDirectory.Simple) && !arguments.Contains(Parameter.SubDirectory.Complex))
        {
            IsValid = true;
            return true;
        }

        return false;
    }
    
    private bool TooManySubDirectoryParametersProvided(string[] arguments)
    {
        if (arguments.Contains(Parameter.SubDirectory.Simple) && arguments.Contains(Parameter.SubDirectory.Complex))
        {
            Message = $"Cannot use both {Parameter.SubDirectory.Simple} and {Parameter.SubDirectory.Complex}";
            IsValid = false;
            return true;
        }

        if (arguments.Count(s => s.Contains(Parameter.SubDirectory.Simple)) <= 1 && arguments.Count(s => s.Contains(Parameter.SubDirectory.Complex)) <= 1)
            return false;
        
        Message = "Cannot use sub directory attribute more than once";
        IsValid = false;
        return true;
    }
}