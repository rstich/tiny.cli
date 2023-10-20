namespace Tiny.Cli.Validation;

public class OutPutDirArgumentValidator : BaseValidator, IArgumentValidator
{
    public bool IsValid { get; private set; }
    public string? Message { get; private set; }

    public string? ValidateArguments(string[] arguments)
    {
        if (NoArgumentProvided(arguments)) return null;
        if (TooManyArgumentsProvided(arguments)) return null;
        /*
         * var outputDir = args.Contains("-o") || args.Contains("--out")
    ? args[Array.IndexOf(args, "-o") + 1]
    : Environment.CurrentDirectory;
         */
        throw new NotImplementedException();
    }

    private bool TooManyArgumentsProvided(string[] arguments)
    {
        if (BothValidatorArgumentsProvided(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex))
        {
            IsValid = false;
            Message = $"Cannot use both {Parameter.OutPutDir.Simple} and {Parameter.OutPutDir.Complex}";
            return true;
        }
        
        if (TooManyValidatorArgumentsProvided(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex))
        {
            IsValid = false;
            Message = "Too many output directory parameters provided";
            return true;
        }
        
        return false;
    }

    private bool NoArgumentProvided(string[] arguments)
    {
        if (ContainsValidatorArgument(arguments, Parameter.OutPutDir.Simple, Parameter.OutPutDir.Complex)) return false;
        
        IsValid = true;
        return true;
    }
}