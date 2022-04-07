using System.Text.RegularExpressions;
using StumpR.ProtoBuilder.Cache;
using StumpR.ProtoBuilder.Model.Parsing;

namespace StumpR.ProtoBuilder.Parser;

/// <summary>
///     Parser for ProtocolTypeManager.as file.
/// </summary>
public static class ProtocolTypeParser
{
    private static readonly Regex _typeManagerDeclaration;

    private static readonly Dictionary<string, int> _types;


    static ProtocolTypeParser()
    {
        _typeManagerDeclaration = RegexCache.Instance.GetRegex(RegexEnum.TypeManagerDeclaration);
        _types = new Dictionary<string, int>();
    }

    public static int TryGetTypeId(string typeName)
    {
        return _types.TryGetValue(typeName, out var id) ? id : 0;
    }

    public static async Task InitializeStore(string pathToProtocolTypeManager)
    {
        var data = (await File.ReadAllTextAsync(pathToProtocolTypeManager)).Replace("\r", "");
        var match = _typeManagerDeclaration.Match(data);

        while (match.Success)
        {
            var typeId = int.Parse(match.Groups["type_id"].Value);
            var typeName = match.Groups["type_name"].Value;

            if (!_types.ContainsKey(typeName)) _types.Add(typeName, typeId);

            match = match.NextMatch();
        }
    }
}