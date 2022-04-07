using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class KickHavenBagRequestMessage : Message
{
    public const uint Id = 188;

    public KickHavenBagRequestMessage(ulong guestId)
    {
        GuestId = guestId;
    }

    public KickHavenBagRequestMessage()
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