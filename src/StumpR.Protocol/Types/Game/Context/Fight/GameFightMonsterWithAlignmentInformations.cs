using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
{
    public new const short Id = 108;

    public GameFightMonsterWithAlignmentInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        GameContextBasicSpawnInformation spawnInfo,
        sbyte wave,
        GameFightCharacteristics stats,
        IEnumerable<ushort> previousPositions,
        ushort creatureGenericId,
        sbyte creatureGrade,
        short creatureLevel,
        ActorAlignmentInformations alignmentInfos)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        SpawnInfo = spawnInfo;
        Wave = wave;
        Stats = stats;
        PreviousPositions = previousPositions;
        CreatureGenericId = creatureGenericId;
        CreatureGrade = creatureGrade;
        CreatureLevel = creatureLevel;
        AlignmentInfos = alignmentInfos;
    }

    public GameFightMonsterWithAlignmentInformations()
    {
    }

    public override short TypeId => Id;

    public ActorAlignmentInformations AlignmentInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        AlignmentInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AlignmentInfos = new ActorAlignmentInformations();
        AlignmentInfos.Deserialize(reader);
    }
}