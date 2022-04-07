using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectsDeletedMessage : Message
{
    public const uint Id = 9871;

    public ObjectsDeletedMessage(IEnumerable<uint> objectUID)
    {
        ObjectUID = objectUID;
    }

    public ObjectsDeletedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<uint> ObjectUID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectUID.Count());
        foreach (uint objectToSend in ObjectUID) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectUIDCount = reader.ReadUShort();
        var objectUID_ = new uint[objectUIDCount];
        for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++) objectUID_[objectUIDIndex] = reader.ReadVarUInt();
        ObjectUID = objectUID_;
    }
}