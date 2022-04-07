using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTeamInformations : AbstractFightTeamInformations
{
    public new const short Id = 4654;

    public FightTeamInformations(sbyte teamId,
        double leaderId,
        sbyte teamSide,
        sbyte teamTypeId,
        sbyte nbWaves,
        IEnumerable<FightTeamMemberInformations> teamMembers)
    {
        TeamId = teamId;
        LeaderId = leaderId;
        TeamSide = teamSide;
        TeamTypeId = teamTypeId;
        NbWaves = nbWaves;
        TeamMembers = teamMembers;
    }

    public FightTeamInformations()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<FightTeamMemberInformations> TeamMembers { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) TeamMembers.Count());

        foreach (FightTeamMemberInformations objectToSend in TeamMembers)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort teamMembersCount = reader.ReadUShort();
        var teamMembers_ = new FightTeamMemberInformations[teamMembersCount];

        for (var teamMembersIndex = 0; teamMembersIndex < teamMembersCount; teamMembersIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<FightTeamMemberInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            teamMembers_[teamMembersIndex] = objectToAdd;
        }
        TeamMembers = teamMembers_;
    }
}