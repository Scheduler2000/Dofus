using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeShopStockMultiMovementRemovedMessage : Message
{
    public const uint Id = 3309;

    public ExchangeShopStockMultiMovementRemovedMessage(IEnumerable<uint> objectIdList)
    {
        ObjectIdList = objectIdList;
    }

    public ExchangeShopStockMultiMovementRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<uint> ObjectIdList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectIdList.Count());
        foreach (uint objectToSend in ObjectIdList) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectIdListCount = reader.ReadUShort();
        var objectIdList_ = new uint[objectIdListCount];

        for (var objectIdListIndex = 0; objectIdListIndex < objectIdListCount; objectIdListIndex++)
            objectIdList_[objectIdListIndex] = reader.ReadVarUInt();
        ObjectIdList = objectIdList_;
    }
}