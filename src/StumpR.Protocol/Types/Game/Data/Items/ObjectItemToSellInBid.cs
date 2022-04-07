using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemToSellInBid : ObjectItemToSell
{
    public new const short Id = 3500;

    public ObjectItemToSellInBid(ushort objectGID,
        IEnumerable<ObjectEffect> effects,
        uint objectUID,
        uint quantity,
        ulong objectPrice,
        int unsoldDelay)
    {
        ObjectGID = objectGID;
        Effects = effects;
        ObjectUID = objectUID;
        Quantity = quantity;
        ObjectPrice = objectPrice;
        UnsoldDelay = unsoldDelay;
    }

    public ObjectItemToSellInBid()
    {
    }

    public override short TypeId => Id;

    public int UnsoldDelay { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(UnsoldDelay);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        UnsoldDelay = reader.ReadInt();
    }
}