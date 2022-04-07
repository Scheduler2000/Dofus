using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeTypesItemsExchangerDescriptionForUserMessage : Message
{
    public const uint Id = 6681;

    public ExchangeTypesItemsExchangerDescriptionForUserMessage(int objectType, IEnumerable<BidExchangerObjectInfo> itemTypeDescriptions)
    {
        ObjectType = objectType;
        ItemTypeDescriptions = itemTypeDescriptions;
    }

    public ExchangeTypesItemsExchangerDescriptionForUserMessage()
    {
    }

    public override uint MessageId => Id;

    public int ObjectType { get; set; }

    public IEnumerable<BidExchangerObjectInfo> ItemTypeDescriptions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(ObjectType);
        writer.WriteShort((short) ItemTypeDescriptions.Count());
        foreach (BidExchangerObjectInfo objectToSend in ItemTypeDescriptions) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectType = reader.ReadInt();
        ushort itemTypeDescriptionsCount = reader.ReadUShort();
        var itemTypeDescriptions_ = new BidExchangerObjectInfo[itemTypeDescriptionsCount];

        for (var itemTypeDescriptionsIndex = 0; itemTypeDescriptionsIndex < itemTypeDescriptionsCount; itemTypeDescriptionsIndex++)
        {
            var objectToAdd = new BidExchangerObjectInfo();
            objectToAdd.Deserialize(reader);
            itemTypeDescriptions_[itemTypeDescriptionsIndex] = objectToAdd;
        }
        ItemTypeDescriptions = itemTypeDescriptions_;
    }
}