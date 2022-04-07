using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectModifyPricedMessage : ExchangeObjectMovePricedMessage
{
    public new const uint Id = 3929;

    public ExchangeObjectModifyPricedMessage(uint objectUID, int quantity, ulong price)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
        Price = price;
    }

    public ExchangeObjectModifyPricedMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}