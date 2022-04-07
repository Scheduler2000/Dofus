using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
{
    public new const short Id = 8132;

    public GuildInsiderFactSheetInformations(uint guildId,
        string guildName,
        byte guildLevel,
        GuildEmblem guildEmblem,
        ulong leaderId,
        ushort nbMembers,
        short lastActivityDay,
        GuildRecruitmentInformation recruitment,
        int nbPendingApply,
        string leaderName,
        ushort nbConnectedMembers,
        sbyte nbTaxCollectors)
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
        LeaderName = leaderName;
        NbConnectedMembers = nbConnectedMembers;
        NbTaxCollectors = nbTaxCollectors;
    }

    public GuildInsiderFactSheetInformations()
    {
    }

    public override short TypeId => Id;

    public string LeaderName { get; set; }

    public ushort NbConnectedMembers { get; set; }

    public sbyte NbTaxCollectors { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(LeaderName);
        writer.WriteVarUShort(NbConnectedMembers);
        writer.WriteSByte(NbTaxCollectors);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        LeaderName = reader.ReadUTF();
        NbConnectedMembers = reader.ReadVarUShort();
        NbTaxCollectors = reader.ReadSByte();
    }
}