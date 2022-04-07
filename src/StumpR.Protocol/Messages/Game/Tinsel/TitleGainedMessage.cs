using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TitleGainedMessage : Message
{
    public const uint Id = 3386;

    public TitleGainedMessage(ushort titleId)
    {
        TitleId = titleId;
    }

    public TitleGainedMessage()
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