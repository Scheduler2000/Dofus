using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightFighterInformations : GameContextActorInformations
{
    public new const short Id = 5068;

    public GameFightFighterInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        GameContextBasicSpawnInformation spawnInfo,
        sbyte wave,
        GameFightCharacteristics stats,
        IEnumerable<ushort> previousPositions)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        SpawnInfo = spawnInfo;
        Wave = wave;
        Stats = stats;
        PreviousPositions = previousPositions;
    }

    public GameFightFighterInformations()
    {
    }

    public override short TypeId => Id;

    public GameContextBasicSpawnInformation SpawnInfo { get; set; }

    public sbyte Wave { get; set; }

    public GameFightCharacteristics Stats { get; set; }

    public IEnumerable<ushort> PreviousPositions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        SpawnInfo.Serialize(writer);
        writer.WriteSByte(Wave);
        writer.WriteShort(Stats.TypeId);
        Stats.Serialize(writer);
        writer.WriteShort((short) PreviousPositions.Count());
        foreach (ushort objectToSend in PreviousPositions) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        SpawnInfo = new GameContextBasicSpawnInformation();
        SpawnInfo.Deserialize(reader);
        Wave = reader.ReadSByte();
        Stats = ProtocolTypeManager.GetInstance<GameFightCharacteristics>(reader.ReadShort());
        Stats.Deserialize(reader);
        ushort previousPositionsCount = reader.ReadUShort();
        var previousPositions_ = new ushort[previousPositionsCount];

        for (var previousPositionsIndex = 0; previousPositionsIndex < previousPositionsCount; previousPositionsIndex++)
            previousPositions_[previousPositionsIndex] = reader.ReadVarUShort();
        PreviousPositions = previousPositions_;
    }
}