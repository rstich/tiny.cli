namespace Tiny.Cli.Validation;

public class OutPutDirArgumentValidator : IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        /*
         * var outputDir = args.Contains("-o") || args.Contains("--out")
    ? args[Array.IndexOf(args, "-o") + 1]
    : Environment.CurrentDirectory;
         */
        throw new NotImplementedException();
    }
}