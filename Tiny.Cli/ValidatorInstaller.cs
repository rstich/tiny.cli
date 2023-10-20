using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tiny.Cli.Validation;

namespace Tiny.Cli;

public static class ValidatorInstaller
{
    public static IServiceCollection InstallArgumentValidators(this IServiceCollection services)
    {
        var types = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IArgumentValidator)));

        foreach (var type in types)
        {
            services.AddTransient(typeof(IArgumentValidator), type);
        }
        
        return services;
    }
}