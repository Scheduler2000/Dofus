using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatClientMultiWithObjectMessage : ChatClientMultiMessage
{
    public new const uint Id = 1682;

    public ChatClientMultiWithObjectMessage(string content, sbyte channel, IEnumerable<ObjectItem> objects)
    {
        Content = content;
        Channel = channel;
        Objects = objects;
    }

    public ChatClientMultiWithObjectMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItem> Objects { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Objects.Count());
        foreach (ObjectItem objectToSend in Objects) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort objectsCount = reader.ReadUShort();
        var objects_ = new ObjectItem[objectsCount];

        for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
        {
            var objectToAdd = new ObjectItem();
            objectToAdd.Deserialize(reader);
            objects_[objectsIndex] = objectToAdd;
        }
        Objects = objects_;
    }
}