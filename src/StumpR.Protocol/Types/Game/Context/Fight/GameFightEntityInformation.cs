using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightEntityInformation : GameFightFighterInformations
{
    public new const short Id = 5544;

    public GameFightEntityInformation(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        GameContextBasicSpawnInformation spawnInfo,
        sbyte wave,
        GameFightCharacteristics stats,
        IEnumerable<ushort> previousPositions,
        sbyte entityModelId,
        ushort level,
        double masterId)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        SpawnInfo = spawnInfo;
        Wave = wave;
        Stats = stats;
        PreviousPositions = previousPositions;
        EntityModelId = entityModelId;
        Level = level;
        MasterId = masterId;
    }

    public GameFightEntityInformation()
    {
    }

    public override short TypeId => Id;

    public sbyte EntityModelId { get; set; }

    public ushort Level { get; set; }

    public double MasterId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(EntityModelId);
        writer.WriteVarUShort(Level);
        writer.WriteDouble(MasterId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        EntityModelId = reader.ReadSByte();
        Level = reader.ReadVarUShort();
        MasterId = reader.ReadDouble();
    }
}