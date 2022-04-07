using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeShopStockMovementUpdatedMessage : Message
{
    public const uint Id = 9932;

    public ExchangeShopStockMovementUpdatedMessage(ObjectItemToSell objectInfo)
    {
        ObjectInfo = objectInfo;
    }

    public ExchangeShopStockMovementUpdatedMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectItemToSell ObjectInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        ObjectInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectInfo = new ObjectItemToSell();
        ObjectInfo.Deserialize(reader);
    }
}