using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeShopStockMultiMovementUpdatedMessage : Message
{
    public const uint Id = 8646;

    public ExchangeShopStockMultiMovementUpdatedMessage(IEnumerable<ObjectItemToSell> objectInfoList)
    {
        ObjectInfoList = objectInfoList;
    }

    public ExchangeShopStockMultiMovementUpdatedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItemToSell> ObjectInfoList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectInfoList.Count());
        foreach (ObjectItemToSell objectToSend in ObjectInfoList) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectInfoListCount = reader.ReadUShort();
        var objectInfoList_ = new ObjectItemToSell[objectInfoListCount];

        for (var objectInfoListIndex = 0; objectInfoListIndex < objectInfoListCount; objectInfoListIndex++)
        {
            var objectToAdd = new ObjectItemToSell();
            objectToAdd.Deserialize(reader);
            objectInfoList_[objectInfoListIndex] = objectToAdd;
        }
        ObjectInfoList = objectInfoList_;
    }
}