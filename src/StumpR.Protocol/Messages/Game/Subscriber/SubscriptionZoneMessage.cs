using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SubscriptionZoneMessage : Message
{
    public const uint Id = 3082;

    public SubscriptionZoneMessage(bool active)
    {
        Active = active;
    }

    public SubscriptionZoneMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Active { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Active);
    }

    public override void Deserialize(IDataReader reader)
    {
        Active = reader.ReadBoolean();
    }
}