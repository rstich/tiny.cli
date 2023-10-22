using Tiny.Cli.Misc;
using Tiny.Cli.Validation;

namespace Tiny.Cli.Service;

public class ArgumentValidationService
{
    private readonly IEnumerable<IArgumentValidator> _validators;
    public ArgumentValidationService(IEnumerable<IArgumentValidator> validators)
    {
        _validators = validators;
    }
    public bool ValidateArguments(string[] arguments)
    {
        WorkFlowParameters parameters = new();
        var argumentsAreValid = true;
        foreach (var validator in _validators)
        {
            validator.ValidateArguments(arguments, parameters);
            if (!validator.IsValid)
            {
                argumentsAreValid = false;
            }
        }

        _validators.Select(v => v.Message)
            .Where(v => v != null)
            .ToList()
            .ForEach(Console.WriteLine);
        
        return argumentsAreValid;
    }
}