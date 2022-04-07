using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WatchInventoryContentMessage : InventoryContentMessage
{
    public new const uint Id = 8233;

    public WatchInventoryContentMessage(IEnumerable<ObjectItem> objects, ulong kamas)
    {
        Objects = objects;
        Kamas = kamas;
    }

    public WatchInventoryContentMessage()
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