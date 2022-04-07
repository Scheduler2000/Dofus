using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemGenericQuantity : Item
{
    public new const short Id = 7873;

    public ObjectItemGenericQuantity(ushort objectGID, uint quantity)
    {
        ObjectGID = objectGID;
        Quantity = quantity;
    }

    public ObjectItemGenericQuantity()
    {
    }

    public override short TypeId => Id;

    public ushort ObjectGID { get; set; }

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(ObjectGID);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectGID = reader.ReadVarUShort();
        Quantity = reader.ReadVarUInt();
    }
}