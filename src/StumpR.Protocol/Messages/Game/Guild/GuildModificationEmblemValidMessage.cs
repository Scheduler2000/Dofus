using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildModificationEmblemValidMessage : Message
{
    public const uint Id = 3249;

    public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem)
    {
        GuildEmblem = guildEmblem;
    }

    public GuildModificationEmblemValidMessage()
    {
    }

    public override uint MessageId => Id;

    public GuildEmblem GuildEmblem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        GuildEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        GuildEmblem = new GuildEmblem();
        GuildEmblem.Deserialize(reader);
    }
}