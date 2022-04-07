using StumpR.ProtoBuilder.Parser.Enum;

namespace StumpR.ProtoBuilder.Converter.Enum;

public class EnumGenerator : ProtocolGenerator
{
    public EnumGenerator(string directoryPath)
        : base(directoryPath, SearchOption.TopDirectoryOnly, new EnumParser())
    { }
}