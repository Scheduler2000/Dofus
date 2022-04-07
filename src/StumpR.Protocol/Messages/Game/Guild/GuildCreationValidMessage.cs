using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildCreationValidMessage : Message
{
    public const uint Id = 1395;

    public GuildCreationValidMessage(string guildName, GuildEmblem guildEmblem)
    {
        GuildName = guildName;
        GuildEmblem = guildEmblem;
    }

    public GuildCreationValidMessage()
    {
    }

    public override uint MessageId => Id;

    public string GuildName { get; set; }

    public GuildEmblem GuildEmblem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(GuildName);
        GuildEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        GuildName = reader.ReadUTF();
        GuildEmblem = new GuildEmblem();
        GuildEmblem.Deserialize(reader);
    }
}