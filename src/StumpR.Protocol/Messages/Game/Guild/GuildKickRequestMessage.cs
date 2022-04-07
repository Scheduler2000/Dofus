using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildKickRequestMessage : Message
{
    public const uint Id = 3965;

    public GuildKickRequestMessage(ulong kickedId)
    {
        KickedId = kickedId;
    }

    public GuildKickRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong KickedId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(KickedId);
    }

    public override void Deserialize(IDataReader reader)
    {
        KickedId = reader.ReadVarULong();
    }
}