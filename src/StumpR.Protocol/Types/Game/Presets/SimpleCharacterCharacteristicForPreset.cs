using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SimpleCharacterCharacteristicForPreset
{
    public const short Id = 7495;

    public SimpleCharacterCharacteristicForPreset(string keyword, short @base, short additionnal)
    {
        Keyword = keyword;
        this.@base = @base;
        Additionnal = additionnal;
    }

    public SimpleCharacterCharacteristicForPreset()
    {
    }

    public virtual short TypeId => Id;

    public string Keyword { get; set; }

    public short @base { get; set; }

    public short Additionnal { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Keyword);
        writer.WriteVarShort(@base);
        writer.WriteVarShort(Additionnal);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Keyword = reader.ReadUTF();
        @base = reader.ReadVarShort();
        Additionnal = reader.ReadVarShort();
    }
}