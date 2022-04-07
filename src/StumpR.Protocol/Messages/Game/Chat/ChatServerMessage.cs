using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatServerMessage : ChatAbstractServerMessage
{
    public new const uint Id = 8853;

    public ChatServerMessage(sbyte channel,
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

    public ChatServerMessage()
    {
    }

    public override uint MessageId => Id;

    public double SenderId { get; set; }

    public string SenderName { get; set; }

    public string Prefix { get; set; }

    public int SenderAccountId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(SenderId);
        writer.WriteUTF(SenderName);
        writer.WriteUTF(Prefix);
        writer.WriteInt(SenderAccountId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        SenderId = reader.ReadDouble();
        SenderName = reader.ReadUTF();
        Prefix = reader.ReadUTF();
        SenderAccountId = reader.ReadInt();
    }
}