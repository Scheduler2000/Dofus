// ReSharper disable ConstantNullCoalescingCondition

using Microsoft.Extensions.Configuration;

namespace StumpR.ProtoBuilder.Cache;

public class ConfigurationCache
{
    private static ConfigurationCache _instance;

    private ConfigurationCache()
    {
        var workingDirectory = Directory.GetCurrentDirectory();
        var projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;

        Configuration = new ConfigurationBuilder()
            .AddJsonFile($"{projectDirectory}/appsettings.json", false)
            .Build();
    }

    public static ConfigurationCache Instance => _instance ??= new ConfigurationCache();

    public IConfigurationRoot Configuration { get; set; }
}