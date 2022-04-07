using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TitleSelectRequestMessage : Message
{
    public const uint Id = 8025;

    public TitleSelectRequestMessage(ushort titleId)
    {
        TitleId = titleId;
    }

    public TitleSelectRequestMessage()
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