using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdentificationFailedMessage : Message
{
    public const uint Id = 7135;

    public IdentificationFailedMessage(sbyte reason)
    {
        Reason = reason;
    }

    public IdentificationFailedMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
    }
}