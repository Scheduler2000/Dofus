using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightMutantInformations : GameFightFighterNamedInformations
{
    public new const short Id = 2861;

    public GameFightMutantInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        GameContextBasicSpawnInformation spawnInfo,
        sbyte wave,
        GameFightCharacteristics stats,
        IEnumerable<ushort> previousPositions,
        string name,
        PlayerStatus status,
        short leagueId,
        int ladderPosition,
        bool hiddenInPrefight,
        sbyte powerLevel)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        SpawnInfo = spawnInfo;
        Wave = wave;
        Stats = stats;
        PreviousPositions = previousPositions;
        Name = name;
        Status = status;
        LeagueId = leagueId;
        LadderPosition = ladderPosition;
        HiddenInPrefight = hiddenInPrefight;
        PowerLevel = powerLevel;
    }

    public GameFightMutantInformations()
    {
    }

    public override short TypeId => Id;

    public sbyte PowerLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(PowerLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PowerLevel = reader.ReadSByte();
    }
}