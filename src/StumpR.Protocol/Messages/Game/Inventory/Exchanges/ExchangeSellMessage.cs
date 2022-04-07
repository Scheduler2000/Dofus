using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeSellMessage : Message
{
    public const uint Id = 5196;

    public ExchangeSellMessage(uint objectToSellId, uint quantity)
    {
        ObjectToSellId = objectToSellId;
        Quantity = quantity;
    }

    public ExchangeSellMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectToSellId { get; set; }

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectToSellId);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectToSellId = reader.ReadVarUInt();
        Quantity = reader.ReadVarUInt();
    }
}