using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class OrnamentGainedMessage : Message
{
    public const uint Id = 3920;

    public OrnamentGainedMessage(short ornamentId)
    {
        OrnamentId = ornamentId;
    }

    public OrnamentGainedMessage()
    {
    }

    public override uint MessageId => Id;

    public short OrnamentId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(OrnamentId);
    }

    public override void Deserialize(IDataReader reader)
    {
        OrnamentId = reader.ReadShort();
    }
}