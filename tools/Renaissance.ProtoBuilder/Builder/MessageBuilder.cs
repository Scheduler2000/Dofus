using System.IO;

using Renaissance.Tools.ProtoBuilder.Parsing;

namespace Renaissance.Tools.ProtoBuilder.Builder
{
    public class MessageBuilder : AbstractBuilder<MessageConverter>
    {
        public MessageBuilder(string directoryPath)
            : base(directoryPath, SearchOption.AllDirectories) { }


    }
}
