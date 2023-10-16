using TinifyAPI;

var tinyKey = Environment.GetEnvironmentVariable("TINY_KEY");

if (tinyKey is null)
{
    Console.WriteLine("Please set the TINY_KEY environment variable by typing:");
    Console.WriteLine("set TINY_KEY=your_api_key");
    return;
}

Tinify.Key = tinyKey; // Your API key


if (args.Length == 0 || args.Contains("-h") || args.Contains("--help"))
{
    PrintHelp();
    return;
}

var singleFile = args.Contains("-f") || args.Contains("--file")
    ? args[Array.IndexOf(args, "-f") + 1]
    : null;

var directory = args.Contains("-c") || args.Contains("--current")  
    ? Environment.CurrentDirectory
    : args.Contains("-d") || args.Contains("--dir") 
        ? args[Array.IndexOf(args, "-d") + 1]
        : Environment.CurrentDirectory;

var searchOption = args.Contains("-r") || args.Contains("--recurse")
    ? SearchOption.AllDirectories
    : SearchOption.TopDirectoryOnly;

var outputDir = args.Contains("-o") || args.Contains("--out")
    ? args[Array.IndexOf(args, "-o") + 1]
    : Environment.CurrentDirectory;

try
{
    if (singleFile is not null)
    {
        Console.WriteLine($"Optimizing {singleFile}");
        var source = Tinify.FromFile(singleFile);
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
    Console.WriteLine("  -r, --recurse          Optimize all images in the current (or provided) directory and subdirectories");
    Console.WriteLine("  -f, --file <filename>  Optimize the specific file");
    Console.WriteLine("  -d, --dir <directory>  Optimize all images in the specific directory");
    Console.WriteLine("  -o, --out <directory>  Output directory for optimized images");
}