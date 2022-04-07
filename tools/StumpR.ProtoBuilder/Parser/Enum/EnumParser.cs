using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using StumpR.ProtoBuilder.Cache;
using StumpR.ProtoBuilder.Model.Parsing;
using StumpR.ProtoBuilder.Model.Rendering;
using StumpR.ProtoBuilder.Model.Rendering.Builder;

namespace StumpR.ProtoBuilder.Parser.Enum;

public class EnumParser : IParser
{
    private readonly Regex _classDeclaration;
    private readonly IConfigurationRoot _configuration;
    private readonly Regex _enumItemDeclaration;

    private EnumParser(RegexCache regexCache, IConfigurationRoot configuration)
    {
        _classDeclaration = regexCache.GetRegex(RegexEnum.ClassDeclaration);
        _enumItemDeclaration = regexCache.GetRegex(RegexEnum.EnumItemDeclaration);
        _configuration = configuration;
    }

    public EnumParser() : this(RegexCache.Instance, ConfigurationCache.Instance.Configuration)
    { }

    public ParserTypeEnum ParserType => ParserTypeEnum.Enum;

    public TemplateInfo Parse(string filePath)
    {
        var className = Path.GetFileNameWithoutExtension(filePath);
        var data = File.ReadAllText(filePath);

        EnumInfoBuilder enumInfoBuilder = new();
        enumInfoBuilder.SetNamespace(_configuration["NamespacesRoot:Enums"]);

        IList<string> directives = _configuration.GetSection("Directives:Enums").Get<List<string>>();

        if (directives != null)
            foreach (var ns in directives)
                enumInfoBuilder.AddDirective(new DirectiveInfo(ns));

        var match = _classDeclaration.Match(data);

        if (!match.Success) throw new Exception($"The class : {className} is not a valide as3 class !");

        enumInfoBuilder.SetName(match.Groups["name"].Value);

        match = _enumItemDeclaration.Match(data);

        while (match.Success)
        {
            var key = match.Groups["name"].Value;
            var value = match.Groups["value"].Value;
            EnumItemInfo elt = new(key, value);

            enumInfoBuilder.AddEnum(elt);

            match = match.NextMatch();
        }

        var enumInfo = enumInfoBuilder.Build();
        TemplateInfo template = new(enumInfo);

        return template;
    }
}