using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatAdminServerMessage : ChatServerMessage
{
    public new const uint Id = 6581;

    public ChatAdminServerMessage(sbyte channel,
        string content,
        int timestamp,
        string fingerprint,
        double senderId,
        string senderName,
        string prefix,
        int senderAccountId)
    {
        Channel = channel;
        Content = content;
        Timestamp = timestamp;
        Fingerprint = fingerprint;
        SenderId = senderId;
        SenderName = senderName;
        Prefix = prefix;
        SenderAccountId = senderAccountId;
    }

    public ChatAdminServerMessage()
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