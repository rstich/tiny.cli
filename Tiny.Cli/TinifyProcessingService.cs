using TinifyAPI;

namespace Tiny.Cli;

public class TinifyProcessingService
{
    private readonly ArgumentValidationService _argumentValidationService;

    public TinifyProcessingService(ArgumentValidationService argumentValidationService)
    {
        _argumentValidationService = argumentValidationService;
    }
    
    public void Process(string[] arguments)
    {
        if (EnvironmentSettingValid())
        {
            var argumentsValid = _argumentValidationService.ValidateArguments(arguments);
        }
    }
    
    private static bool EnvironmentSettingValid()
    {
        var tinyKey = Environment.GetEnvironmentVariable("TINY_KEY");

        if (tinyKey is null)
        {
            Console.WriteLine("Please set the TINY_KEY environment variable by typing:");
            Console.WriteLine("set TINY_KEY=your_api_key");
            return false;
        }

        Tinify.Key = tinyKey; // Your API key4
        return true;
    }
    
    /*
     * try
{
    if (singleFile is not null)
    {
        Console.WriteLine($"Optimizing {singleFile}");
        var source = Tinify.FromFile(singleFile);

        if (resize is not null)
        {
            source = AddResizeIfNeeded(source, singleFile, resize);
        }

        await source.ToFile(Path.Combine(outputDir, Path.GetFileName(singleFile)));
        
        return;
    }

    var files = Directory.GetFiles(directory, "*.*", searchOption)
        .Where(file => file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg"));

    var fileEnum = files.ToList();
    var filesCount = fileEnum.Count;
    if (filesCount == 0)
    {
        Console.WriteLine("No images found");
        return;
    }

    Console.WriteLine($"Found {filesCount} images");
    foreach (var file in fileEnum)
    {
        var index = fileEnum.IndexOf(file) + 1;
        Console.WriteLine($"{index}/{filesCount} Optimizing {file}");

        var source = Tinify.FromFile(file);
        
        if (resize is not null)
        {
            source = AddResizeIfNeeded(source, file, resize);
        }
        
        await source.ToFile(Path.Combine(outputDir, Path.GetFileName(file)));
    }
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Done");
var compressionsThisMonth = Tinify.CompressionCount;
Console.WriteLine($"Compressions this month: {compressionsThisMonth}");

static void PrintHelp()
{
    Console.WriteLine("Usage: tiny [option] [argument]");
    Console.WriteLine("");
    Console.WriteLine("Options:");
    Console.WriteLine("  -h, --help             Show this help information");
    Console.WriteLine("  -c, --current          Optimize all images in the current directory");
    Console.WriteLine("  -s, --subdir           Optimize all images in the current (or provided) directory and subdirectories");
    Console.WriteLine("  -f, --file <filename>  Optimize the specific file");
    Console.WriteLine("  -d, --dir <directory>  Optimize all images in the specific directory");
    Console.WriteLine("  -o, --out <directory>  Output directory for optimized images");
    Console.WriteLine("  -r, --resize <size>    resize to specific size (only one number)");
}

Task<Source> AddResizeIfNeeded(Task<Source> task, string filePath, string targetResize)
{
    using var image = Image.Load(filePath);
    int width = image.Width;
    int height = image.Height;

    int target = Convert.ToInt32(targetResize);
    if (width > target || height > target)
    {
        task = task.Resize(new
        {
            method = "fit",
            width = target,
            height = target
        });                    
    }

    return task;
}
     */
}