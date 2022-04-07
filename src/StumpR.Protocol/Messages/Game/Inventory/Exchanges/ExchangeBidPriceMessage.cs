using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidPriceMessage : Message
{
    public const uint Id = 8533;

    public ExchangeBidPriceMessage(ushort genericId, long averagePrice)
    {
        GenericId = genericId;
        AveragePrice = averagePrice;
    }

    public ExchangeBidPriceMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort GenericId { get; set; }

    public long AveragePrice { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(GenericId);
        writer.WriteVarLong(AveragePrice);
    }

    public override void Deserialize(IDataReader reader)
    {
        GenericId = reader.ReadVarUShort();
        AveragePrice = reader.ReadVarLong();
    }
}