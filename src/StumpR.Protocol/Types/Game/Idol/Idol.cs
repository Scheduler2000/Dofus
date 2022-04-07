using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class Idol
{
    public const short Id = 960;

    public Idol(ushort objectId, ushort xpBonusPercent, ushort dropBonusPercent)
    {
        ObjectId = objectId;
        XpBonusPercent = xpBonusPercent;
        DropBonusPercent = dropBonusPercent;
    }

    public Idol()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObjectId { get; set; }

    public ushort XpBonusPercent { get; set; }

    public ushort DropBonusPercent { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
        writer.WriteVarUShort(XpBonusPercent);
        writer.WriteVarUShort(DropBonusPercent);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
        XpBonusPercent = reader.ReadVarUShort();
        DropBonusPercent = reader.ReadVarUShort();
    }
}