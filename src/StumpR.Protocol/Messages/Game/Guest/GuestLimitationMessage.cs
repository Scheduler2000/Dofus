using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuestLimitationMessage : Message
{
    public const uint Id = 1036;

    public GuestLimitationMessage(sbyte reason)
    {
        Reason = reason;
    }

    public GuestLimitationMessage()
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