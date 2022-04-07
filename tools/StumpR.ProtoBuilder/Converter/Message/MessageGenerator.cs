using StumpR.ProtoBuilder.Parser.Message;

namespace StumpR.ProtoBuilder.Converter.Message;

public class MessageGenerator : ProtocolGenerator
{
    public MessageGenerator(string directoryPath)
        : base(directoryPath, SearchOption.AllDirectories, new MessageParser())
    { }
}