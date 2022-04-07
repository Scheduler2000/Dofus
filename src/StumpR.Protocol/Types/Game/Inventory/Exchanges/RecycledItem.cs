using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class RecycledItem
{
    public const short Id = 161;

    public RecycledItem(ushort objectId, uint qty)
    {
        ObjectId = objectId;
        Qty = qty;
    }

    public RecycledItem()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObjectId { get; set; }

    public uint Qty { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
        writer.WriteUInt(Qty);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
        Qty = reader.ReadUInt();
    }
}