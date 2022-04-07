using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
{
    public new const short Id = 4715;

    public ObjectItemInformationWithQuantity(ushort objectGID, IEnumerable<ObjectEffect> effects, uint quantity)
    {
        ObjectGID = objectGID;
        Effects = effects;
        Quantity = quantity;
    }

    public ObjectItemInformationWithQuantity()
    {
    }

    public override short TypeId => Id;

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Quantity = reader.ReadVarUInt();
    }
}