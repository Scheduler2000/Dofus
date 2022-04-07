using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
{
    public new const uint Id = 8645;

    public ExchangeBidPriceForSellerMessage(ushort genericId, long averagePrice, bool allIdentical, IEnumerable<ulong> minimalPrices)
    {
        GenericId = genericId;
        AveragePrice = averagePrice;
        AllIdentical = allIdentical;
        MinimalPrices = minimalPrices;
    }

    public ExchangeBidPriceForSellerMessage()
    {
    }

    public override uint MessageId => Id;

    public bool AllIdentical { get; set; }

    public IEnumerable<ulong> MinimalPrices { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(AllIdentical);
        writer.WriteShort((short) MinimalPrices.Count());
        foreach (ulong objectToSend in MinimalPrices) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllIdentical = reader.ReadBoolean();
        ushort minimalPricesCount = reader.ReadUShort();
        var minimalPrices_ = new ulong[minimalPricesCount];

        for (var minimalPricesIndex = 0; minimalPricesIndex < minimalPricesCount; minimalPricesIndex++)
            minimalPrices_[minimalPricesIndex] = reader.ReadVarULong();
        MinimalPrices = minimalPrices_;
    }
}