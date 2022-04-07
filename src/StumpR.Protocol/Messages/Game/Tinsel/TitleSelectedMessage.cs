using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TitleSelectedMessage : Message
{
    public const uint Id = 8922;

    public TitleSelectedMessage(ushort titleId)
    {
        TitleId = titleId;
    }

    public TitleSelectedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort TitleId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(TitleId);
    }

    public override void Deserialize(IDataReader reader)
    {
        TitleId = reader.ReadVarUShort();
    }
}