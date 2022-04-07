using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StorageObjectsRemoveMessage : Message
{
    public const uint Id = 7044;

    public StorageObjectsRemoveMessage(IEnumerable<uint> objectUIDList)
    {
        ObjectUIDList = objectUIDList;
    }

    public StorageObjectsRemoveMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<uint> ObjectUIDList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectUIDList.Count());
        foreach (uint objectToSend in ObjectUIDList) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectUIDListCount = reader.ReadUShort();
        var objectUIDList_ = new uint[objectUIDListCount];

        for (var objectUIDListIndex = 0; objectUIDListIndex < objectUIDListCount; objectUIDListIndex++)
            objectUIDList_[objectUIDListIndex] = reader.ReadVarUInt();
        ObjectUIDList = objectUIDList_;
    }
}