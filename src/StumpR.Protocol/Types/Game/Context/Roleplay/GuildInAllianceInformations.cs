using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildInAllianceInformations : GuildInformations
{
    public new const short Id = 8343;

    public GuildInAllianceInformations(uint guildId,
        string guildName,
        byte guildLevel,
        GuildEmblem guildEmblem,
        byte nbMembers,
        int joinDate)
    {
        GuildId = guildId;
        GuildName = guildName;
        GuildLevel = guildLevel;
        GuildEmblem = guildEmblem;
        NbMembers = nbMembers;
        JoinDate = joinDate;
    }

    public GuildInAllianceInformations()
    {
    }

    public override short TypeId => Id;

    public byte NbMembers { get; set; }

    public int JoinDate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteByte(NbMembers);
        writer.WriteInt(JoinDate);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        NbMembers = reader.ReadByte();
        JoinDate = reader.ReadInt();
    }
}