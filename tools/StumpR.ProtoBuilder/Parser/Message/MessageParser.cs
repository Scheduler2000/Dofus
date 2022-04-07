using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using StumpR.ProtoBuilder.Cache;
using StumpR.ProtoBuilder.Helpers;
using StumpR.ProtoBuilder.Model.Parsing;
using StumpR.ProtoBuilder.Model.Rendering;
using StumpR.ProtoBuilder.Model.Rendering.Builder;

namespace StumpR.ProtoBuilder.Parser.Message;

public class MessageParser : IParser
{
    private readonly Regex _classDeclaration;

    private readonly IConfigurationRoot _configuration;
    private readonly Regex _importDeclaration;
    private readonly Regex _initArgsDeclaration;
    private readonly Regex _initDeclaration;
    private readonly Regex _packageDeclaration;
    private readonly PrimitiveTypeCache _primitiveTypeCache;
    private readonly Regex _propertyDeclaration;
    private readonly Regex _protocolIdDeclaration;
    private readonly Regex _vectorTypeDeclaration;


    private MessageParser(RegexCache regexCache, IConfigurationRoot configuration,
        PrimitiveTypeCache primitiveTypeCache)
    {
        _classDeclaration = regexCache.GetRegex(RegexEnum.ClassDeclaration);
        _propertyDeclaration = regexCache.GetRegex(RegexEnum.PropertyDeclaration);
        _vectorTypeDeclaration = regexCache.GetRegex(RegexEnum.VectorTypeDeclaration);
        _packageDeclaration = regexCache.GetRegex(RegexEnum.PackageDeclaration);
        _importDeclaration = regexCache.GetRegex(RegexEnum.ImportDeclaration);
        _protocolIdDeclaration = regexCache.GetRegex(RegexEnum.ProtocolIdDeclaration);
        _initDeclaration = regexCache.GetRegex(RegexEnum.InitFuncDeclaration);
        _initArgsDeclaration = regexCache.GetRegex(RegexEnum.InitArgsDeclaration);

        _configuration = configuration;
        _primitiveTypeCache = primitiveTypeCache;
    }

    public MessageParser() : this(RegexCache.Instance, ConfigurationCache.Instance.Configuration,
        PrimitiveTypeCache.Instance)
    { }

    public ParserTypeEnum ParserType => ParserTypeEnum.Message;

    public TemplateInfo Parse(string filePath)
    {
        var className = Path.GetFileNameWithoutExtension(filePath);
        var data = File.ReadAllText(filePath).Replace("\r", "");

        ClassInfoBuilder classInfoBuilder = new();

        // Match match = _packageDeclaration.Match(data);
        //
        // if (!match.Success) throw new Exception($"The class : {className} is not a valide as3 class !");
        //
        // classInfoBuilder.SetNamespace(
        //     $"{_configuration["NamespacesRoot:Types"]}.{match.Groups["name"].Value.NormalizePackageImport()}");

        classInfoBuilder.SetNamespace($"{_configuration["NamespacesRoot:Messages"]}");

        IList<string> directives = _configuration
            .GetSection("Directives:Messages")
            .Get<List<string>>();

        if (directives != null)
            foreach (var ns in directives)
                classInfoBuilder.AddDirective(new DirectiveInfo(ns));

        // match = _importDeclaration.Match(data);
        //
        // while (match.Success)
        // {
        //     if (!string.IsNullOrEmpty(match.Groups["directive"].Value))
        //     {
        //         var directive = $"{_configuration["NamespacesRoot:Types"]}.{match.Groups["directive"].Value.NormalizePackageImport()}";
        //         classInfoBuilder.AddDirective(new DirectiveInfo(directive.RemoveCharactersFromTheEnd('.')));
        //     }
        //     match = match.NextMatch();
        // }

        var match = _classDeclaration.Match(data);

        if (!match.Success) throw new Exception($"The class : {className} is not a valide as3 class !");

        classInfoBuilder.SetName(match.Groups["name"].Value);

        if (!string.IsNullOrEmpty(match.Groups["parent"].Value) && match.Groups["parent"].Value != "NetworkMessage")
            classInfoBuilder.SetParent(match.Groups["parent"].Value);

        match = _protocolIdDeclaration.Match(data);

        if (!match.Success) throw new Exception($"The class : {className} is not a valide as3 class !");

        var id = int.Parse(match.Groups["value"].Value);

        var protoId = ProtocolTypeParser.TryGetTypeId(className);

        classInfoBuilder.AddProperty(new PropertyInfo("ProtocolId", "int",
            protoId == 0 ? id.ToString() : protoId.ToString(), true));


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

        match = _initDeclaration.Match(data);

        var initArgs = match.Groups["argument"].Value;

        if (!string.IsNullOrEmpty(initArgs))
        {
            match = _initArgsDeclaration.Match(initArgs);

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

                classInfoBuilder.AddParentProperty(propertyInfo);

                match = match.NextMatch();
            }
        }

        var classInfo = classInfoBuilder.Build();
        TemplateInfo template = new(classInfo);

        return template;
    }
}