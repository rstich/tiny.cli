﻿using TinifyAPI;
using Tiny.Cli.Misc;

namespace Tiny.Cli.Service;

public class TinifyWorkFlowProcessor
{
    public async Task Run(WorkFlowParameters parameters)
    {
        try
        {
            Tinify.Key = parameters.ApiKey;
            await Tinify.Validate();
            
            if (parameters.FilePath is not null)
            {
                await TinifyFile(parameters);
            }
            else
            {
                await TinifyDirectory(parameters);
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
    }
    
    private async Task TinifyFile(WorkFlowParameters parameters)
    {
        await TinifyFile(parameters.FilePath!, parameters.OutPutDir!, parameters.Resize);
    }
    
    private async Task TinifyFile(string filePath, string outputDir, int? resize)
    {
        Console.WriteLine($"Optimizing {filePath}");
        var source = Tinify.FromFile(filePath);

        if (resize is not null)
        {
            source = AddResizeIfNeeded(source, filePath, (int)resize);
        }

        await source.ToFile(Path.Combine(outputDir, Path.GetFileName(filePath)));
    }

    private async Task TinifyDirectory(WorkFlowParameters parameters)
    {
        var files = Directory.GetFiles(parameters.Directory!, "*.*", (SearchOption)parameters.SearchOption!)
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

            await TinifyFile(file, parameters.OutPutDir!, parameters.Resize);
        }
    }

    private Task<Source> AddResizeIfNeeded(Task<Source> task, string parametersFilePath, int parametersResize)
    {
        using var image = Image.Load(parametersFilePath);
        int width = image.Width;
        int height = image.Height;

        
        if (width > parametersResize || height > parametersResize)
        {
            task = task.Resize(new
            {
                method = "fit",
                width = parametersResize,
                height = parametersResize
            });                    
        }

        return task;
    }
}