// ReSharper disable ConstantNullCoalescingCondition

#pragma warning disable CS8603
#pragma warning disable CS8600
#pragma warning disable CS8618

namespace StumpR.ProtoBuilder.Cache;

public class PrimitiveTypeCache
{
    private static PrimitiveTypeCache _instance;
    private readonly IDictionary<string, string> _cache;

    private PrimitiveTypeCache()
    {
        _cache = new Dictionary<string, string>
        {
            {"Boolean", "bool"},
            {"String", "string"},
            {"Number", "double"},
            {"int", "int"},
            {"uint", "uint"}
        };
    }

    public static PrimitiveTypeCache Instance => _instance ??= new PrimitiveTypeCache();

    /// <summary>
    ///     Determines if it's an as3 type or not
    /// </summary>
    /// <param name="type">AS3 type</param>
    /// <returns></returns>
    public bool IsPrimitiveType(string type)
    {
        return _cache.ContainsKey(type);
    }

    /// <param name="key">AS3 type</param>
    /// <returns>Returns the corresponding type in C#</returns>
    /// <remarks>If the type isn't a primitive, this methods return the original value type</remarks>
    public string TryToNormalizeType(string key)
    {
        return _cache.TryGetValue(key, out var normalized) ? normalized : key;
    }
}