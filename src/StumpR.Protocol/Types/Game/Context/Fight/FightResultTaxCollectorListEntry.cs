using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
{
    public new const short Id = 1517;

    public FightResultTaxCollectorListEntry(ushort outcome,
        sbyte wave,
        FightLoot rewards,
        double objectId,
        bool alive,
        byte level,
        BasicGuildInformations guildInfo,
        int experienceForGuild)
    {
        Outcome = outcome;
        Wave = wave;
        Rewards = rewards;
        ObjectId = objectId;
        Alive = alive;
        Level = level;
        GuildInfo = guildInfo;
        ExperienceForGuild = experienceForGuild;
    }

    public FightResultTaxCollectorListEntry()
    {
    }

    public override short TypeId => Id;

    public byte Level { get; set; }

    public BasicGuildInformations GuildInfo { get; set; }

    public int ExperienceForGuild { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteByte(Level);
        GuildInfo.Serialize(writer);
        writer.WriteInt(ExperienceForGuild);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Level = reader.ReadByte();
        GuildInfo = new BasicGuildInformations();
        GuildInfo.Deserialize(reader);
        ExperienceForGuild = reader.ReadInt();
    }
}