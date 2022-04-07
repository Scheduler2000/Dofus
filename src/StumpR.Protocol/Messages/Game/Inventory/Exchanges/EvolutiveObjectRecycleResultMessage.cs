using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EvolutiveObjectRecycleResultMessage : Message
{
    public const uint Id = 8805;

    public EvolutiveObjectRecycleResultMessage(IEnumerable<RecycledItem> recycledItems)
    {
        RecycledItems = recycledItems;
    }

    public EvolutiveObjectRecycleResultMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<RecycledItem> RecycledItems { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) RecycledItems.Count());
        foreach (RecycledItem objectToSend in RecycledItems) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort recycledItemsCount = reader.ReadUShort();
        var recycledItems_ = new RecycledItem[recycledItemsCount];

        for (var recycledItemsIndex = 0; recycledItemsIndex < recycledItemsCount; recycledItemsIndex++)
        {
            var objectToAdd = new RecycledItem();
            objectToAdd.Deserialize(reader);
            recycledItems_[recycledItemsIndex] = objectToAdd;
        }
        RecycledItems = recycledItems_;
    }
}