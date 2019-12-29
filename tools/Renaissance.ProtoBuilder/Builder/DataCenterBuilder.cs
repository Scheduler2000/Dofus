using System.IO;

using Renaissance.ProtoBuilder.Parsing;
using Renaissance.Tools.ProtoBuilder.Builder;

namespace Renaissance.ProtoBuilder.Builder
{
    public class DataCenterBuilder : AbstractBuilder<DataCenterConverter>
    {
        public DataCenterBuilder(string directoryPath)
            : base(directoryPath, SearchOption.AllDirectories) { }
    }
}
