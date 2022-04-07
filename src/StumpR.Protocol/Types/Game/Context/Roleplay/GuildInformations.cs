using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildInformations : BasicGuildInformations
{
    public new const short Id = 1201;

    public GuildInformations(uint guildId, string guildName, byte guildLevel, GuildEmblem guildEmblem)
    {
        GuildId = guildId;
        GuildName = guildName;
        GuildLevel = guildLevel;
        GuildEmblem = guildEmblem;
    }

    public GuildInformations()
    {
    }

    public override short TypeId => Id;

    public GuildEmblem GuildEmblem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        GuildEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        GuildEmblem = new GuildEmblem();
        GuildEmblem.Deserialize(reader);
    }
}