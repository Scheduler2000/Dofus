using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightAllianceTeamInformations : FightTeamInformations
{
    public new const short Id = 2398;

    public FightAllianceTeamInformations(sbyte teamId,
        double leaderId,
        sbyte teamSide,
        sbyte teamTypeId,
        sbyte nbWaves,
        IEnumerable<FightTeamMemberInformations> teamMembers,
        sbyte relation)
    {
        TeamId = teamId;
        LeaderId = leaderId;
        TeamSide = teamSide;
        TeamTypeId = teamTypeId;
        NbWaves = nbWaves;
        TeamMembers = teamMembers;
        Relation = relation;
    }

    public FightAllianceTeamInformations()
    {
    }

    public override short TypeId => Id;

    public sbyte Relation { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(Relation);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Relation = reader.ReadSByte();
    }
}