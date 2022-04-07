using StumpR.ProtoBuilder.Model.Parsing;
using StumpR.ProtoBuilder.Model.Rendering;

namespace StumpR.ProtoBuilder.Parser;

public interface IParser
{
    ParserTypeEnum ParserType { get; }

    TemplateInfo Parse(string filePath);
}