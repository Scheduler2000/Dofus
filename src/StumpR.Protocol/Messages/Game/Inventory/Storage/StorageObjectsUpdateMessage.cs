using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StorageObjectsUpdateMessage : Message
{
    public const uint Id = 7209;

    public StorageObjectsUpdateMessage(IEnumerable<ObjectItem> objectList)
    {
        ObjectList = objectList;
    }

    public StorageObjectsUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItem> ObjectList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectList.Count());
        foreach (ObjectItem objectToSend in ObjectList) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectListCount = reader.ReadUShort();
        var objectList_ = new ObjectItem[objectListCount];

        for (var objectListIndex = 0; objectListIndex < objectListCount; objectListIndex++)
        {
            var objectToAdd = new ObjectItem();
            objectToAdd.Deserialize(reader);
            objectList_[objectListIndex] = objectToAdd;
        }
        ObjectList = objectList_;
    }
}