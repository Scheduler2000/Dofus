using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectCreature : ObjectEffect
{
    public new const short Id = 8829;

    public ObjectEffectCreature(ushort actionId, ushort monsterFamilyId)
    {
        ActionId = actionId;
        MonsterFamilyId = monsterFamilyId;
    }

    public ObjectEffectCreature()
    {
    }

    public override short TypeId => Id;

    public ushort MonsterFamilyId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(MonsterFamilyId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MonsterFamilyId = reader.ReadVarUShort();
    }
}