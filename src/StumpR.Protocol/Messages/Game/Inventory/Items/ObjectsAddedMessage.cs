using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectsAddedMessage : Message
{
    public const uint Id = 1568;

    public ObjectsAddedMessage(IEnumerable<ObjectItem> @object)
    {
        this.@object = @object;
    }

    public ObjectsAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItem> @object { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) @object.Count());
        foreach (ObjectItem objectToSend in @object) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectCount = reader.ReadUShort();
        var object_ = new ObjectItem[objectCount];

        for (var objectIndex = 0; objectIndex < objectCount; objectIndex++)
        {
            var objectToAdd = new ObjectItem();
            objectToAdd.Deserialize(reader);
            object_[objectIndex] = objectToAdd;
        }
        @object = object_;
    }
}