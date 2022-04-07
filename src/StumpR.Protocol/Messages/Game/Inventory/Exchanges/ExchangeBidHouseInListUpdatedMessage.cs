using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
{
    public new const uint Id = 5031;

    public ExchangeBidHouseInListUpdatedMessage(int itemUID,
        ushort objectGID,
        int objectType,
        IEnumerable<ObjectEffect> effects,
        IEnumerable<ulong> prices)
    {
        ItemUID = itemUID;
        ObjectGID = objectGID;
        ObjectType = objectType;
        Effects = effects;
        Prices = prices;
    }

    public ExchangeBidHouseInListUpdatedMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}