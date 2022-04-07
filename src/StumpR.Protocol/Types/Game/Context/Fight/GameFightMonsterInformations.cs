using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightMonsterInformations : GameFightAIInformations
{
    public new const short Id = 1922;

    public GameFightMonsterInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        GameContextBasicSpawnInformation spawnInfo,
        sbyte wave,
        GameFightCharacteristics stats,
        IEnumerable<ushort> previousPositions,
        ushort creatureGenericId,
        sbyte creatureGrade,
        short creatureLevel)
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
    }

    public GameFightMonsterInformations()
    {
    }

    public override short TypeId => Id;

    public ushort CreatureGenericId { get; set; }

    public sbyte CreatureGrade { get; set; }

    public short CreatureLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(CreatureGenericId);
        writer.WriteSByte(CreatureGrade);
        writer.WriteShort(CreatureLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CreatureGenericId = reader.ReadVarUShort();
        CreatureGrade = reader.ReadSByte();
        CreatureLevel = reader.ReadShort();
    }
}