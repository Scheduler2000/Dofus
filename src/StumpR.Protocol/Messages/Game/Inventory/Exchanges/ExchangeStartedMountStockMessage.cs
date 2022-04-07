using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartedMountStockMessage : Message
{
    public const uint Id = 5729;

    public ExchangeStartedMountStockMessage(IEnumerable<ObjectItem> objectsInfos)
    {
        ObjectsInfos = objectsInfos;
    }

    public ExchangeStartedMountStockMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItem> ObjectsInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectsInfos.Count());
        foreach (ObjectItem objectToSend in ObjectsInfos) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectsInfosCount = reader.ReadUShort();
        var objectsInfos_ = new ObjectItem[objectsInfosCount];

        for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
        {
            var objectToAdd = new ObjectItem();
            objectToAdd.Deserialize(reader);
            objectsInfos_[objectsInfosIndex] = objectToAdd;
        }
        ObjectsInfos = objectsInfos_;
    }
}