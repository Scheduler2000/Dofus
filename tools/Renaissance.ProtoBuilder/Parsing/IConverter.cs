using System.Text;

namespace Renaissance.Tools.ProtoBuilder.Parsing
{
    public enum ConverterType
    {
        Enum,
        NetworkMessage,
        NetworkType,
        D2OType,
    }

    public interface IConverter
    {
        ConverterType ConverterType { get; }

        StringBuilder Convert(string filePath);
    }
}
