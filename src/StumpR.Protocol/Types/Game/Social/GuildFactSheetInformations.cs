using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildFactSheetInformations : GuildInformations
{
    public new const short Id = 7387;

    public GuildFactSheetInformations(uint guildId,
        string guildName,
        byte guildLevel,
        GuildEmblem guildEmblem,
        ulong leaderId,
        ushort nbMembers,
        short lastActivityDay,
        GuildRecruitmentInformation recruitment,
        int nbPendingApply)
    {
        GuildId = guildId;
        GuildName = guildName;
        GuildLevel = guildLevel;
        GuildEmblem = guildEmblem;
        LeaderId = leaderId;
        NbMembers = nbMembers;
        LastActivityDay = lastActivityDay;
        Recruitment = recruitment;
        NbPendingApply = nbPendingApply;
    }

    public GuildFactSheetInformations()
    {
    }

    public override short TypeId => Id;

    public ulong LeaderId { get; set; }

    public ushort NbMembers { get; set; }

    public short LastActivityDay { get; set; }

    public GuildRecruitmentInformation Recruitment { get; set; }

    public int NbPendingApply { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(LeaderId);
        writer.WriteVarUShort(NbMembers);
        writer.WriteShort(LastActivityDay);
        Recruitment.Serialize(writer);
        writer.WriteInt(NbPendingApply);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        LeaderId = reader.ReadVarULong();
        NbMembers = reader.ReadVarUShort();
        LastActivityDay = reader.ReadShort();
        Recruitment = new GuildRecruitmentInformation();
        Recruitment.Deserialize(reader);
        NbPendingApply = reader.ReadInt();
    }
}