using System.Diagnostics;
using System.Reflection;
using NuGet.Configuration;
using NuGet.Protocol.Core.Types;
using Tiny.Cli.Misc;
using NullLogger = NuGet.Common.NullLogger;

namespace Tiny.Cli.Service;

public class VersionService
{
    private readonly CacheObjectManager _cacheObjectManager;
    public VersionService(CacheObjectManager cacheObjectManager)
    {
        _cacheObjectManager = cacheObjectManager;
    }
    
    public async Task CheckAndUpdateVersion(string[] args)
    {
        var versionCheckNeeded = await _cacheObjectManager.CacheExpired() || await UpdateParameterIsSet(args);
        if(!versionCheckNeeded) return;
        
        var comparisonResult = await CompareRunningVersionWithNuget();
        if (comparisonResult < 0)
        {
            Console.WriteLine("There is a newer version of the tool available. Would you like to update? y/n");
            var input = Console.ReadLine();
            await UpdateVersion(input);
        }
        
        CacheObjectManager.ConfigurationObject.LastUpdateCheck = DateTime.Now;
        await _cacheObjectManager.UpdateCache();
    }

    private Task<bool> UpdateParameterIsSet(string[] args)
    {
        return Task.FromResult(args.Contains(Parameter.Update.Simple) || args.Contains(Parameter.Update.Complex));
    }

    private async Task<int> CompareRunningVersionWithNuget()
    {
        Assembly? assembly = Assembly.GetEntryAssembly();
        Version? toolVersion = assembly?.GetName().Version;
        var assemblyName = assembly?.GetName().Name;

        var nugetVersion = await GetLatestVersionFromNuget(assemblyName!);

        var comparisonResult = toolVersion?.CompareTo(nugetVersion) ?? 0;
        return comparisonResult;
    }

    private async Task<Version> GetLatestVersionFromNuget(string assemblyName)
    {
        var packageSourceProvider = new PackageSourceProvider(Settings.LoadDefaultSettings(null));
        var packageSources = packageSourceProvider.LoadPackageSources().ToList();
        var repositoryProvider = new SourceRepositoryProvider(packageSourceProvider, Repository.Provider.GetCoreV3());
        var sourceRepository = repositoryProvider.CreateRepository(packageSources.First());

        var resource = await sourceRepository.GetResourceAsync<FindPackageByIdResource>();

        var packageVersions = await resource.GetAllVersionsAsync(assemblyName, new SourceCacheContext(), NullLogger.Instance, CancellationToken.None);

        var latestVersion = packageVersions.MaxBy(v => v);
        
        Console.WriteLine($"Latest version of {assemblyName}: {latestVersion}");

        var nugetVersion = new Version("1.0.0");
        if (latestVersion != null)
        {
            nugetVersion = new Version(latestVersion.ToString());
        }
        
        return nugetVersion;
    }

    private async Task UpdateVersion(string? input)
    {
        if (input is not null && input.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Updating...");
            await UpdateTool();
        }
    }

    private async Task UpdateTool()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "tool update -g Tiny.Cli",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        while (await process.StandardOutput.ReadLineAsync() is { } line)
        {
            Console.WriteLine(line);
        }
        
        await process.WaitForExitAsync();
        Console.WriteLine("Update complete.");
    }
}