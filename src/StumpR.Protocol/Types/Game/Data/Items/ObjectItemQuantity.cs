using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemQuantity : Item
{
    public new const short Id = 3674;

    public ObjectItemQuantity(uint objectUID, uint quantity)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
    }

    public ObjectItemQuantity()
    {
    }

    public override short TypeId => Id;

    public uint ObjectUID { get; set; }

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(ObjectUID);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectUID = reader.ReadVarUInt();
        Quantity = reader.ReadVarUInt();
    }
}