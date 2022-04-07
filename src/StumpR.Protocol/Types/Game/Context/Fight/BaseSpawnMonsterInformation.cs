using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class BaseSpawnMonsterInformation : SpawnInformation
{
    public new const short Id = 736;

    public BaseSpawnMonsterInformation(ushort creatureGenericId)
    {
        CreatureGenericId = creatureGenericId;
    }

    public BaseSpawnMonsterInformation()
    {
    }

    public override short TypeId => Id;

    public ushort CreatureGenericId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(CreatureGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CreatureGenericId = reader.ReadVarUShort();
    }
}