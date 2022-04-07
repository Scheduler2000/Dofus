using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportHavenBagRequestMessage : Message
{
    public const uint Id = 5838;

    public TeleportHavenBagRequestMessage(ulong guestId)
    {
        GuestId = guestId;
    }

    public TeleportHavenBagRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong GuestId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(GuestId);
    }

    public override void Deserialize(IDataReader reader)
    {
        GuestId = reader.ReadVarULong();
    }
}