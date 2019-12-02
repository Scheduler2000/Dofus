using System.IO;
using Renaissance.Tools.ProtoBuilder.Parsing;

namespace Renaissance.Tools.ProtoBuilder.Builder
{
    public class TypeBuilder : AbstractBuilder<TypeConverter>
    {
        public TypeBuilder(string directoryPath)
            : base(directoryPath, SearchOption.AllDirectories) { }

    }
}
