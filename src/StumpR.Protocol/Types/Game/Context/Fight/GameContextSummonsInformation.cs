using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameContextSummonsInformation
{
    public const short Id = 253;

    public GameContextSummonsInformation(SpawnInformation spawnInformation,
        sbyte wave,
        EntityLook look,
        GameFightCharacteristics stats,
        IEnumerable<GameContextBasicSpawnInformation> summons)
    {
        SpawnInformation = spawnInformation;
        Wave = wave;
        Look = look;
        Stats = stats;
        Summons = summons;
    }

    public GameContextSummonsInformation()
    {
    }

    public virtual short TypeId => Id;

    public SpawnInformation SpawnInformation { get; set; }

    public sbyte Wave { get; set; }

    public EntityLook Look { get; set; }

    public GameFightCharacteristics Stats { get; set; }

    public IEnumerable<GameContextBasicSpawnInformation> Summons { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort(SpawnInformation.TypeId);
        SpawnInformation.Serialize(writer);
        writer.WriteSByte(Wave);
        Look.Serialize(writer);
        writer.WriteShort(Stats.TypeId);
        Stats.Serialize(writer);
        writer.WriteShort((short) Summons.Count());

        foreach (GameContextBasicSpawnInformation objectToSend in Summons)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public virtual void Deserialize(IDataReader reader)
    {
        SpawnInformation = ProtocolTypeManager.GetInstance<SpawnInformation>(reader.ReadShort());
        SpawnInformation.Deserialize(reader);
        Wave = reader.ReadSByte();
        Look = new EntityLook();
        Look.Deserialize(reader);
        Stats = ProtocolTypeManager.GetInstance<GameFightCharacteristics>(reader.ReadShort());
        Stats.Deserialize(reader);
        ushort summonsCount = reader.ReadUShort();
        var summons_ = new GameContextBasicSpawnInformation[summonsCount];

        for (var summonsIndex = 0; summonsIndex < summonsCount; summonsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameContextBasicSpawnInformation>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            summons_[summonsIndex] = objectToAdd;
        }
        Summons = summons_;
    }
}