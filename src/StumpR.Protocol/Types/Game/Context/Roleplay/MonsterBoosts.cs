using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MonsterBoosts
{
    public const short Id = 7719;

    public MonsterBoosts(uint objectId, ushort xpBoost, ushort dropBoost)
    {
        ObjectId = objectId;
        XpBoost = xpBoost;
        DropBoost = dropBoost;
    }

    public MonsterBoosts()
    {
    }

    public virtual short TypeId => Id;

    public uint ObjectId { get; set; }

    public ushort XpBoost { get; set; }

    public ushort DropBoost { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectId);
        writer.WriteVarUShort(XpBoost);
        writer.WriteVarUShort(DropBoost);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUInt();
        XpBoost = reader.ReadVarUShort();
        DropBoost = reader.ReadVarUShort();
    }
}