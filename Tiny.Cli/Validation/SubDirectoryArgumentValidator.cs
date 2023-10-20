namespace Tiny.Cli.Validation;

public class SubDirectoryArgumentValidator : IArgumentValidator
{
    private bool _isValid;
    private string? _message;
    
    public bool IsValid()
    {
        return _isValid;
    }

    public string? ValidateArguments(string[] arguments)
    {
        /*var searchOption = args.Contains("-s") || args.Contains("--subdir")
            ? SearchOption.AllDirectories
            : SearchOption.TopDirectoryOnly;*/
        throw new NotImplementedException();
    }

    public string? GetMessage()
    {
        return _message;
    }
}