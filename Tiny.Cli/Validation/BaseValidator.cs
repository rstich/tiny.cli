namespace Tiny.Cli.Validation;

public abstract class BaseValidator
{
    protected bool ContainsValidatorArgument(string[] arguments, string simple, string complex)
    {
        return arguments.Contains(simple) || arguments.Contains(complex);
    }
    protected bool TooManyValidatorArgumentsProvided(string[] arguments, string firstArgument, string secondArgument)
    {
        return arguments.Count(s => s.Contains(firstArgument)) > 1 || arguments.Count(s => s.Contains(secondArgument)) > 1;
    }

    protected bool BothValidatorArgumentsProvided(string[] arguments, string firstArgument, string secondArgument)
    {
        return arguments.Contains(firstArgument) && arguments.Contains(secondArgument);
    }
    
    protected int GetArgumentIndex(string[] arguments, string simpleArgument, string complexArgument)
    {
        return Array.IndexOf(arguments, arguments.Contains(simpleArgument) ? simpleArgument : complexArgument);
    }
}