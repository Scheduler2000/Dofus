using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuestModeMessage : Message
{
    public const uint Id = 9430;

    public GuestModeMessage(bool active)
    {
        Active = active;
    }

    public GuestModeMessage()
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