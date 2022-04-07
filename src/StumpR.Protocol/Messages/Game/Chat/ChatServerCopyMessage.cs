using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatServerCopyMessage : ChatAbstractServerMessage
{
    public new const uint Id = 5344;

    public ChatServerCopyMessage(sbyte channel, string content, int timestamp, string fingerprint, ulong receiverId, string receiverName)
    {
        Channel = channel;
        Content = content;
        Timestamp = timestamp;
        Fingerprint = fingerprint;
        ReceiverId = receiverId;
        ReceiverName = receiverName;
    }

    public ChatServerCopyMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ReceiverId { get; set; }

    public string ReceiverName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(ReceiverId);
        writer.WriteUTF(ReceiverName);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ReceiverId = reader.ReadVarULong();
        ReceiverName = reader.ReadUTF();
    }
}