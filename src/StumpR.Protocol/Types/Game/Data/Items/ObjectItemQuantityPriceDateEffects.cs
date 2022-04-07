using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemQuantityPriceDateEffects : ObjectItemGenericQuantity
{
    public new const short Id = 7217;

    public ObjectItemQuantityPriceDateEffects(ushort objectGID, uint quantity, ulong price, ObjectEffects effects, int date)
    {
        ObjectGID = objectGID;
        Quantity = quantity;
        Price = price;
        Effects = effects;
        Date = date;
    }

    public ObjectItemQuantityPriceDateEffects()
    {
    }

    public override short TypeId => Id;

    public ulong Price { get; set; }

    public ObjectEffects Effects { get; set; }

    public int Date { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Price);
        Effects.Serialize(writer);
        writer.WriteInt(Date);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Price = reader.ReadVarULong();
        Effects = new ObjectEffects();
        Effects.Deserialize(reader);
        Date = reader.ReadInt();
    }
}