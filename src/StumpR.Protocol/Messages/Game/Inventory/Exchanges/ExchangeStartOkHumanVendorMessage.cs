using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartOkHumanVendorMessage : Message
{
    public const uint Id = 9011;

    public ExchangeStartOkHumanVendorMessage(double sellerId, IEnumerable<ObjectItemToSellInHumanVendorShop> objectsInfos)
    {
        SellerId = sellerId;
        ObjectsInfos = objectsInfos;
    }

    public ExchangeStartOkHumanVendorMessage()
    {
    }

    public override uint MessageId => Id;

    public double SellerId { get; set; }

    public IEnumerable<ObjectItemToSellInHumanVendorShop> ObjectsInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(SellerId);
        writer.WriteShort((short) ObjectsInfos.Count());
        foreach (ObjectItemToSellInHumanVendorShop objectToSend in ObjectsInfos) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        SellerId = reader.ReadDouble();
        ushort objectsInfosCount = reader.ReadUShort();
        var objectsInfos_ = new ObjectItemToSellInHumanVendorShop[objectsInfosCount];

        for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
        {
            var objectToAdd = new ObjectItemToSellInHumanVendorShop();
            objectToAdd.Deserialize(reader);
            objectsInfos_[objectsInfosIndex] = objectToAdd;
        }
        ObjectsInfos = objectsInfos_;
    }
}