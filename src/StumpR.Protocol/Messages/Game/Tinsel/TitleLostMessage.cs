using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TitleLostMessage : Message
{
    public const uint Id = 1427;

    public TitleLostMessage(ushort titleId)
    {
        TitleId = titleId;
    }

    public TitleLostMessage()
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