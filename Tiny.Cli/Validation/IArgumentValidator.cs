namespace Tiny.Cli.Validation;

public interface IArgumentValidator
{
    public bool IsValid();
    public string? ValidateArguments(string[] arguments);
    public string? GetMessage();
}