using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionGuild : HumanOption
{
    public new const short Id = 1437;

    public HumanOptionGuild(GuildInformations guildInformations)
    {
        GuildInformations = guildInformations;
    }

    public HumanOptionGuild()
    {
    }

    public override short TypeId => Id;

    public GuildInformations GuildInformations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        GuildInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        GuildInformations = new GuildInformations();
        GuildInformations.Deserialize(reader);
    }
}