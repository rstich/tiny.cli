using Tiny.Cli.Validation;

namespace Tiny.Cli;

public class ArgumentValidationService
{
    private readonly IEnumerable<IArgumentValidator> _validators;
    public ArgumentValidationService(IEnumerable<IArgumentValidator> validators)
    {
        _validators = validators;
    }
    public string? ValidateArguments(string[] arguments)
    {
        foreach (var validator in _validators)
        {
            //ParseArguments Methode
            //GetResult Methode
            //ValidationResult Objekt
            //ValidationError Property
            var commands = validator.ValidateArguments(arguments);
            if (commands is not null)
            {
                return commands;
            }
        }
        return null;
    }
    
    private string ProvideHelpMessage()
    {
        return @"Usage: tiny [option] [argument]

        Options:
        -h, --help             Show this help information
        -c, --current          Optimize all images in the current directory
        -s, --subdir           Optimize all images in the current (or provided) directory and subdirectories
        -f, --file <filename>  Optimize the specific file
        -d, --dir <directory>  Optimize all images in the specific directory
        -o, --out <directory>  Output directory for optimized images
        -r, --resize <size>    resize to specific size (only one number)";
    }
}