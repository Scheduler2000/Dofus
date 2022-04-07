using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionTitle : HumanOption
{
    public new const short Id = 1813;

    public HumanOptionTitle(ushort titleId, string titleParam)
    {
        TitleId = titleId;
        TitleParam = titleParam;
    }

    public HumanOptionTitle()
    {
    }

    public override short TypeId => Id;

    public ushort TitleId { get; set; }

    public string TitleParam { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(TitleId);
        writer.WriteUTF(TitleParam);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TitleId = reader.ReadVarUShort();
        TitleParam = reader.ReadUTF();
    }
}