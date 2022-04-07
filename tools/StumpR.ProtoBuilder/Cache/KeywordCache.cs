namespace StumpR.ProtoBuilder.Cache;

/// <summary>
///     <see cref="KeywordCache" /> is a cache containing the forbidden words in C#
/// </summary>
public class KeywordCache
{
    private static KeywordCache _instance;
    private readonly List<string> _forbidden;

    public KeywordCache()
    {
        _forbidden = new List<string>
        {
            "base",
            "lock",
            "object"
        };
    }

    public static KeywordCache Instance => _instance ??= new KeywordCache();

    public bool EnsureWord(string str)
    {
        return !_forbidden.Contains(str);
    }
}