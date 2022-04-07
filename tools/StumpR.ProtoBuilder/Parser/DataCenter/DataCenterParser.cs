using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using StumpR.ProtoBuilder.Cache;
using StumpR.ProtoBuilder.Helpers;
using StumpR.ProtoBuilder.Model.Parsing;
using StumpR.ProtoBuilder.Model.Rendering;
using StumpR.ProtoBuilder.Model.Rendering.Builder;

#pragma warning disable CS8604
#pragma warning disable CS8600

namespace StumpR.ProtoBuilder.Parser.DataCenter;

public class DataCenterParser : IParser
{
    private readonly Regex _classDeclaration;
    private readonly IConfigurationRoot _configuration;
    private readonly Regex _packageDeclaration;
    private readonly PrimitiveTypeCache _primitiveTypeCache;
    private readonly Regex _propertyDeclaration;
    private readonly Regex _vectorTypeDeclaration;

    private DataCenterParser(RegexCache regexCache, IConfigurationRoot configuration,
        PrimitiveTypeCache primitiveTypeCache)
    {
        _classDeclaration = regexCache.GetRegex(RegexEnum.ClassDeclaration);
        _propertyDeclaration = regexCache.GetRegex(RegexEnum.PropertyDeclaration);
        _vectorTypeDeclaration = regexCache.GetRegex(RegexEnum.VectorTypeDeclaration);
        _packageDeclaration = regexCache.GetRegex(RegexEnum.PackageDeclaration);

        _configuration = configuration;
        _primitiveTypeCache = primitiveTypeCache;
    }

    public DataCenterParser() : this(RegexCache.Instance, ConfigurationCache.Instance.Configuration,
        PrimitiveTypeCache.Instance)
    { }

    public ParserTypeEnum ParserType => ParserTypeEnum.DataCenter;

    public TemplateInfo Parse(string filePath)
    {
        var className = Path.GetFileNameWithoutExtension(filePath);
        var data = File.ReadAllText(filePath).Replace("\r", "");

        ClassInfoBuilder classInfoBuilder = new();

        classInfoBuilder.SetNamespace(_configuration["NamespacesRoot:DataCenter"]);

        IList<string> directives = _configuration
            .GetSection("Directives:DataCenter")
            .Get<List<string>>();

        if (directives != null)
            foreach (var ns in directives)
                classInfoBuilder.AddDirective(new DirectiveInfo(ns));

        // Match match = _packageDeclaration.Match(data);
        //
        // if (!match.Success) throw new Exception($"The class : {className} is not a valide as3 class !");
        //
        // classInfoBuilder.AddDirective(
        //     new DirectiveInfo($"{_configuration["NamespacesRoot:DataCenter"]}.{match.Groups["name"].Value.NormalizePackageImport()}"));

        var match = _classDeclaration.Match(data);

        if (!match.Success) throw new Exception($"The class : {className} is not a valide as3 class !");

        classInfoBuilder.SetName(match.Groups["name"].Value);

        if (!string.IsNullOrEmpty(match.Groups["parent"].Value))
            classInfoBuilder.SetParent(match.Groups["parent"].Value);

        match = _propertyDeclaration.Match(data);

        while (match.Success)
        {
            var name = match.Groups["name"].Value.Capitalize();
            var type = match.Groups["type"].Value;
            var normalized = _primitiveTypeCache.TryToNormalizeType(type);

            if (name == className) name = $"@{name}";

            if (_vectorTypeDeclaration.IsMatch(type))
                normalized = _vectorTypeDeclaration.Match(type).Groups["vector_type"].Success
                    ? $"List<{_primitiveTypeCache.TryToNormalizeType(_vectorTypeDeclaration.Match(type).Groups["vector_type"].Value)}>"
                    : $"List<List<{_primitiveTypeCache.TryToNormalizeType(_vectorTypeDeclaration.Match(type).Groups["vector_of_vector_type"].Value)}>>";

            PropertyInfo propertyInfo = new(name, normalized);

            classInfoBuilder.AddProperty(propertyInfo);
            match = match.NextMatch();
        }

        var classInfo = classInfoBuilder.Build();
        TemplateInfo template = new(classInfo);

        return template;
    }
}