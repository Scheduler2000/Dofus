using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightCommonInformations
{
    public const short Id = 5008;

    public FightCommonInformations(ushort fightId,
        sbyte fightType,
        IEnumerable<FightTeamInformations> fightTeams,
        IEnumerable<ushort> fightTeamsPositions,
        IEnumerable<FightOptionsInformations> fightTeamsOptions)
    {
        FightId = fightId;
        FightType = fightType;
        FightTeams = fightTeams;
        FightTeamsPositions = fightTeamsPositions;
        FightTeamsOptions = fightTeamsOptions;
    }

    public FightCommonInformations()
    {
    }

    public virtual short TypeId => Id;

    public ushort FightId { get; set; }

    public sbyte FightType { get; set; }

    public IEnumerable<FightTeamInformations> FightTeams { get; set; }

    public IEnumerable<ushort> FightTeamsPositions { get; set; }

    public IEnumerable<FightOptionsInformations> FightTeamsOptions { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteSByte(FightType);
        writer.WriteShort((short) FightTeams.Count());

        foreach (FightTeamInformations objectToSend in FightTeams)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) FightTeamsPositions.Count());
        foreach (ushort objectToSend in FightTeamsPositions) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) FightTeamsOptions.Count());
        foreach (FightOptionsInformations objectToSend in FightTeamsOptions) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        FightType = reader.ReadSByte();
        ushort fightTeamsCount = reader.ReadUShort();
        var fightTeams_ = new FightTeamInformations[fightTeamsCount];

        for (var fightTeamsIndex = 0; fightTeamsIndex < fightTeamsCount; fightTeamsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<FightTeamInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            fightTeams_[fightTeamsIndex] = objectToAdd;
        }
        FightTeams = fightTeams_;
        ushort fightTeamsPositionsCount = reader.ReadUShort();
        var fightTeamsPositions_ = new ushort[fightTeamsPositionsCount];

        for (var fightTeamsPositionsIndex = 0; fightTeamsPositionsIndex < fightTeamsPositionsCount; fightTeamsPositionsIndex++)
            fightTeamsPositions_[fightTeamsPositionsIndex] = reader.ReadVarUShort();
        FightTeamsPositions = fightTeamsPositions_;
        ushort fightTeamsOptionsCount = reader.ReadUShort();
        var fightTeamsOptions_ = new FightOptionsInformations[fightTeamsOptionsCount];

        for (var fightTeamsOptionsIndex = 0; fightTeamsOptionsIndex < fightTeamsOptionsCount; fightTeamsOptionsIndex++)
        {
            var objectToAdd = new FightOptionsInformations();
            objectToAdd.Deserialize(reader);
            fightTeamsOptions_[fightTeamsOptionsIndex] = objectToAdd;
        }
        FightTeamsOptions = fightTeamsOptions_;
    }
}