using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SpawnMonsterInformation : BaseSpawnMonsterInformation
{
    public new const short Id = 3120;

    public SpawnMonsterInformation(ushort creatureGenericId, sbyte creatureGrade)
    {
        CreatureGenericId = creatureGenericId;
        CreatureGrade = creatureGrade;
    }

    public SpawnMonsterInformation()
    {
    }

    public override short TypeId => Id;

    public sbyte CreatureGrade { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(CreatureGrade);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CreatureGrade = reader.ReadSByte();
    }
}