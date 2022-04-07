using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseItemAddOkMessage : Message
{
    public const uint Id = 7844;

    public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo)
    {
        ItemInfo = itemInfo;
    }

    public ExchangeBidHouseItemAddOkMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectItemToSellInBid ItemInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        ItemInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ItemInfo = new ObjectItemToSellInBid();
        ItemInfo.Deserialize(reader);
    }
}