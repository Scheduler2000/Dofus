using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SubscriptionLimitationMessage : Message
{
    public const uint Id = 969;

    public SubscriptionLimitationMessage(sbyte reason)
    {
        Reason = reason;
    }

    public SubscriptionLimitationMessage()
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