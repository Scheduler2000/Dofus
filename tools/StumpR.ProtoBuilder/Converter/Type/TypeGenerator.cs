using StumpR.ProtoBuilder.Parser.Type;

namespace StumpR.ProtoBuilder.Converter.Type;

public class TypeGenerator : ProtocolGenerator
{
    public TypeGenerator(string directoryPath)
        : base(directoryPath, SearchOption.AllDirectories, new TypeParser())
    { }
}