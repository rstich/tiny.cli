namespace Tiny.Cli.Validation;

public interface IArgumentValidator
{
    bool IsValid { get; }
    string? Message { get; }
    
    public string? ValidateArguments(string[] arguments);
}