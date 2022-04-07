using StumpR.ProtoBuilder.Parser.DataCenter;

namespace StumpR.ProtoBuilder.Converter.DataCenter;

public class DatacenterGenerator : ProtocolGenerator
{
    public DatacenterGenerator(string directoryPath)
        : base(directoryPath, SearchOption.AllDirectories, new DataCenterParser())
    { }
}