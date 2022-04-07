using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTeamLightInformations : AbstractFightTeamInformations
{
    public new const short Id = 68;

    public FightTeamLightInformations(sbyte teamId,
        double leaderId,
        sbyte teamSide,
        sbyte teamTypeId,
        sbyte nbWaves,
        bool hasFriend,
        bool hasGuildMember,
        bool hasAllianceMember,
        bool hasGroupMember,
        bool hasMyTaxCollector,
        sbyte teamMembersCount,
        uint meanLevel)
    {
        TeamId = teamId;
        LeaderId = leaderId;
        TeamSide = teamSide;
        TeamTypeId = teamTypeId;
        NbWaves = nbWaves;
        HasFriend = hasFriend;
        HasGuildMember = hasGuildMember;
        HasAllianceMember = hasAllianceMember;
        HasGroupMember = hasGroupMember;
        HasMyTaxCollector = hasMyTaxCollector;
        TeamMembersCount = teamMembersCount;
        MeanLevel = meanLevel;
    }

    public FightTeamLightInformations()
    {
    }

    public override short TypeId => Id;

    public bool HasFriend { get; set; }

    public bool HasGuildMember { get; set; }

    public bool HasAllianceMember { get; set; }

    public bool HasGroupMember { get; set; }

    public bool HasMyTaxCollector { get; set; }

    public sbyte TeamMembersCount { get; set; }

    public uint MeanLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, HasFriend);
        flag = BooleanByteWrapper.SetFlag(flag, 1, HasGuildMember);
        flag = BooleanByteWrapper.SetFlag(flag, 2, HasAllianceMember);
        flag = BooleanByteWrapper.SetFlag(flag, 3, HasGroupMember);
        flag = BooleanByteWrapper.SetFlag(flag, 4, HasMyTaxCollector);
        writer.WriteByte(flag);
        writer.WriteSByte(TeamMembersCount);
        writer.WriteVarUInt(MeanLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        byte flag = reader.ReadByte();
        HasFriend = BooleanByteWrapper.GetFlag(flag, 0);
        HasGuildMember = BooleanByteWrapper.GetFlag(flag, 1);
        HasAllianceMember = BooleanByteWrapper.GetFlag(flag, 2);
        HasGroupMember = BooleanByteWrapper.GetFlag(flag, 3);
        HasMyTaxCollector = BooleanByteWrapper.GetFlag(flag, 4);
        TeamMembersCount = reader.ReadSByte();
        MeanLevel = reader.ReadVarUInt();
    }
}