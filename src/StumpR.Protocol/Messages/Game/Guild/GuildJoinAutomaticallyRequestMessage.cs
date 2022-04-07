using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildJoinAutomaticallyRequestMessage : Message
{
    public const uint Id = 6478;

    public GuildJoinAutomaticallyRequestMessage(int guildId)
    {
        GuildId = guildId;
    }

    public GuildJoinAutomaticallyRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public int GuildId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(GuildId);
    }

    public override void Deserialize(IDataReader reader)
    {
        GuildId = reader.ReadInt();
    }
}