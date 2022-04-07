using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectLadder : ObjectEffectCreature
{
    public new const short Id = 7384;

    public ObjectEffectLadder(ushort actionId, ushort monsterFamilyId, uint monsterCount)
    {
        ActionId = actionId;
        MonsterFamilyId = monsterFamilyId;
        MonsterCount = monsterCount;
    }

    public ObjectEffectLadder()
    {
    }

    public override short TypeId => Id;

    public uint MonsterCount { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(MonsterCount);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MonsterCount = reader.ReadVarUInt();
    }
}