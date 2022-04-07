using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartedBidSellerMessage : Message
{
    public const uint Id = 7532;

    public ExchangeStartedBidSellerMessage(SellerBuyerDescriptor sellerDescriptor, IEnumerable<ObjectItemToSellInBid> objectsInfos)
    {
        SellerDescriptor = sellerDescriptor;
        ObjectsInfos = objectsInfos;
    }

    public ExchangeStartedBidSellerMessage()
    {
    }

    public override uint MessageId => Id;

    public SellerBuyerDescriptor SellerDescriptor { get; set; }

    public IEnumerable<ObjectItemToSellInBid> ObjectsInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        SellerDescriptor.Serialize(writer);
        writer.WriteShort((short) ObjectsInfos.Count());
        foreach (ObjectItemToSellInBid objectToSend in ObjectsInfos) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        SellerDescriptor = new SellerBuyerDescriptor();
        SellerDescriptor.Deserialize(reader);
        ushort objectsInfosCount = reader.ReadUShort();
        var objectsInfos_ = new ObjectItemToSellInBid[objectsInfosCount];

        for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
        {
            var objectToAdd = new ObjectItemToSellInBid();
            objectToAdd.Deserialize(reader);
            objectsInfos_[objectsInfosIndex] = objectToAdd;
        }
        ObjectsInfos = objectsInfos_;
    }
}