using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatServerWithObjectMessage : ChatServerMessage
{
    public new const uint Id = 5967;

    public ChatServerWithObjectMessage(sbyte channel,
        string content,
        int timestamp,
        string fingerprint,
        double senderId,
        string senderName,
        string prefix,
        int senderAccountId,
        IEnumerable<ObjectItem> objects)
    {
        Channel = channel;
        Content = content;
        Timestamp = timestamp;
        Fingerprint = fingerprint;
        SenderId = senderId;
        SenderName = senderName;
        Prefix = prefix;
        SenderAccountId = senderAccountId;
        Objects = objects;
    }

    public ChatServerWithObjectMessage()
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