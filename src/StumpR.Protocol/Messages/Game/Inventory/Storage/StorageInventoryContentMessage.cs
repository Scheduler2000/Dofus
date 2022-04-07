﻿using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StorageInventoryContentMessage : InventoryContentMessage
{
    public new const uint Id = 561;

    public StorageInventoryContentMessage(IEnumerable<ObjectItem> objects, ulong kamas)
    {
        Objects = objects;
        Kamas = kamas;
    }

    public StorageInventoryContentMessage()
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