// ReSharper disable ConstantNullCoalescingCondition

#pragma warning disable CS8618

using System.Text.RegularExpressions;
using StumpR.ProtoBuilder.Model.Parsing;

namespace StumpR.ProtoBuilder.Cache;

public class RegexCache
{
    private static RegexCache _instance;
    private readonly IDictionary<RegexEnum, Regex> _cache;

    private RegexCache()
    {
        _cache = new Dictionary<RegexEnum, Regex>
        {
            {
                RegexEnum.PackageDeclaration,
                new Regex(
                    @"^[\s]*package\s+com.ankamagames.dofus.((network.messages.)|(network.types.)|(datacenter.))*(?<name>[\w|\.]+)\s*$",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.ImportDeclaration,
                new Regex(
                    @"^[\s]*import\s+com.ankamagames.dofus.((network.messages.)|(network.types.)|(datacenter.))*(?<directive>[\w|\.]+)\s*;$",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.ClassDeclaration,
                new Regex(
                    @"public\s*[final]*\s+class\s+(?<name>[\w]+)(\s*extends*\s*(?<parent>[\w]*))?",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.EnumItemDeclaration,
                new Regex(
                    @"^[\s]*public\s+static\s+const\s+(?<name>[\w|_]+)\s*:\s*(?<type>[\w]+)\s*=\s*(?<value>[-+|\d||\w]+)\s*;\s*$",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.ProtocolIdDeclaration,
                new Regex(
                    @"^\s*public\s*static\s*const\s*(?<name>[\w]+)\s*:\s*(?<type>[\w]+)\s*=\s*(?<value>[\d]+)\s*;\s*$",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.PropertyDeclaration,
                new Regex(@"^[\s]*public[\s]*var[\s*](?<name>[\w]*):(?<type>[^=; ]*)",
                    RegexOptions.Multiline)
            },
            {
                RegexEnum.VectorTypeDeclaration,
                new Regex(@"Vector\.<(?<vector_type>[\w]+)>|Vector\.<Vector\.<(?<vector_of_vector_type>[\w]+)>>")
            },

            {
                RegexEnum.InitFuncDeclaration,
                new Regex(@"public\s+\s*function\s+init(?<name>\w+)\((?<argument>[^)]+,?)*",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.InitArgsDeclaration,
                new Regex(@"(?<name>[\w]*):(?<type>[^=; ]*)",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.TypeManagerDeclaration,
                new Regex(@"^\s*_typesTypes\[(?<type_id>[0-9]+)\] = (?<type_name>[\w]+);$",
                    RegexOptions.Multiline)
            },

            {
                RegexEnum.MessageReceiverDeclaration,
                new Regex(@"^\s*_messagesTypes\[(?<message_id>[0-9]+)\] = (?<message_name>[\w]+);$",
                    RegexOptions.Multiline)
            }
        };
    }

    public static RegexCache Instance => _instance ??= new RegexCache();

    public Regex GetRegex(RegexEnum key)
    {
        return _cache[key];
    }
}