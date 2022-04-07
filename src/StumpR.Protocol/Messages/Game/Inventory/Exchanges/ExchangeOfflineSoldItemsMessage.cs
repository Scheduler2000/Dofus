using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeOfflineSoldItemsMessage : Message
{
    public const uint Id = 5671;

    public ExchangeOfflineSoldItemsMessage(IEnumerable<ObjectItemQuantityPriceDateEffects> bidHouseItems,
        IEnumerable<ObjectItemQuantityPriceDateEffects> merchantItems)
    {
        BidHouseItems = bidHouseItems;
        MerchantItems = merchantItems;
    }

    public ExchangeOfflineSoldItemsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItemQuantityPriceDateEffects> BidHouseItems { get; set; }

    public IEnumerable<ObjectItemQuantityPriceDateEffects> MerchantItems { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) BidHouseItems.Count());
        foreach (ObjectItemQuantityPriceDateEffects objectToSend in BidHouseItems) objectToSend.Serialize(writer);
        writer.WriteShort((short) MerchantItems.Count());
        foreach (ObjectItemQuantityPriceDateEffects objectToSend in MerchantItems) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort bidHouseItemsCount = reader.ReadUShort();
        var bidHouseItems_ = new ObjectItemQuantityPriceDateEffects[bidHouseItemsCount];

        for (var bidHouseItemsIndex = 0; bidHouseItemsIndex < bidHouseItemsCount; bidHouseItemsIndex++)
        {
            var objectToAdd = new ObjectItemQuantityPriceDateEffects();
            objectToAdd.Deserialize(reader);
            bidHouseItems_[bidHouseItemsIndex] = objectToAdd;
        }
        BidHouseItems = bidHouseItems_;
        ushort merchantItemsCount = reader.ReadUShort();
        var merchantItems_ = new ObjectItemQuantityPriceDateEffects[merchantItemsCount];

        for (var merchantItemsIndex = 0; merchantItemsIndex < merchantItemsCount; merchantItemsIndex++)
        {
            var objectToAdd = new ObjectItemQuantityPriceDateEffects();
            objectToAdd.Deserialize(reader);
            merchantItems_[merchantItemsIndex] = objectToAdd;
        }
        MerchantItems = merchantItems_;
    }
}