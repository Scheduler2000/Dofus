using System.IO;

using Renaissance.Tools.ProtoBuilder.Parsing;

namespace Renaissance.Tools.ProtoBuilder.Builder
{
    public class EnumBuilder : AbstractBuilder<EnumConverter>
    {
        public EnumBuilder(string directoryPath)
            : base(directoryPath, SearchOption.TopDirectoryOnly) { }
    }
}
