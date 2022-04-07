using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseUnsoldItemsMessage : Message
{
    public const uint Id = 5576;

    public ExchangeBidHouseUnsoldItemsMessage(IEnumerable<ObjectItemGenericQuantity> items)
    {
        Items = items;
    }

    public ExchangeBidHouseUnsoldItemsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItemGenericQuantity> Items { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Items.Count());
        foreach (ObjectItemGenericQuantity objectToSend in Items) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort itemsCount = reader.ReadUShort();
        var items_ = new ObjectItemGenericQuantity[itemsCount];

        for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
        {
            var objectToAdd = new ObjectItemGenericQuantity();
            objectToAdd.Deserialize(reader);
            items_[itemsIndex] = objectToAdd;
        }
        Items = items_;
    }
}