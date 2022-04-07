using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SpawnScaledMonsterInformation : BaseSpawnMonsterInformation
{
    public new const short Id = 6368;

    public SpawnScaledMonsterInformation(ushort creatureGenericId, short creatureLevel)
    {
        CreatureGenericId = creatureGenericId;
        CreatureLevel = creatureLevel;
    }

    public SpawnScaledMonsterInformation()
    {
    }

    public override short TypeId => Id;

    public short CreatureLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(CreatureLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CreatureLevel = reader.ReadShort();
    }
}