using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AbstractFightTeamInformations
{
    public const short Id = 3071;

    public AbstractFightTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves)
    {
        TeamId = teamId;
        LeaderId = leaderId;
        TeamSide = teamSide;
        TeamTypeId = teamTypeId;
        NbWaves = nbWaves;
    }

    public AbstractFightTeamInformations()
    {
    }

    public virtual short TypeId => Id;

    public sbyte TeamId { get; set; }

    public double LeaderId { get; set; }

    public sbyte TeamSide { get; set; }

    public sbyte TeamTypeId { get; set; }

    public sbyte NbWaves { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(TeamId);
        writer.WriteDouble(LeaderId);
        writer.WriteSByte(TeamSide);
        writer.WriteSByte(TeamTypeId);
        writer.WriteSByte(NbWaves);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        TeamId = reader.ReadSByte();
        LeaderId = reader.ReadDouble();
        TeamSide = reader.ReadSByte();
        TeamTypeId = reader.ReadSByte();
        NbWaves = reader.ReadSByte();
    }
}