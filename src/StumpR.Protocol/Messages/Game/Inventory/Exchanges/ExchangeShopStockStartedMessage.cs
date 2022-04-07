using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeShopStockStartedMessage : Message
{
    public const uint Id = 2502;

    public ExchangeShopStockStartedMessage(IEnumerable<ObjectItemToSell> objectsInfos)
    {
        ObjectsInfos = objectsInfos;
    }

    public ExchangeShopStockStartedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItemToSell> ObjectsInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectsInfos.Count());
        foreach (ObjectItemToSell objectToSend in ObjectsInfos) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectsInfosCount = reader.ReadUShort();
        var objectsInfos_ = new ObjectItemToSell[objectsInfosCount];

        for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
        {
            var objectToAdd = new ObjectItemToSell();
            objectToAdd.Deserialize(reader);
            objectsInfos_[objectsInfosIndex] = objectToAdd;
        }
        ObjectsInfos = objectsInfos_;
    }
}