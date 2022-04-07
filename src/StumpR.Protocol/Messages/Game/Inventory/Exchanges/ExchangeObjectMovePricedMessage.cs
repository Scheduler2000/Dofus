using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
{
    public new const uint Id = 1384;

    public ExchangeObjectMovePricedMessage(uint objectUID, int quantity, ulong price)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
        Price = price;
    }

    public ExchangeObjectMovePricedMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Price { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Price);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Price = reader.ReadVarULong();
    }
}