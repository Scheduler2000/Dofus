using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatKolizeumServerMessage : ChatServerMessage
{
    public new const uint Id = 4380;

    public ChatKolizeumServerMessage(sbyte channel,
        string content,
        int timestamp,
        string fingerprint,
        double senderId,
        string senderName,
        string prefix,
        int senderAccountId,
        short originServerId)
    {
        Channel = channel;
        Content = content;
        Timestamp = timestamp;
        Fingerprint = fingerprint;
        SenderId = senderId;
        SenderName = senderName;
        Prefix = prefix;
        SenderAccountId = senderAccountId;
        OriginServerId = originServerId;
    }

    public ChatKolizeumServerMessage()
    {
    }

    public override uint MessageId => Id;

    public short OriginServerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(OriginServerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        OriginServerId = reader.ReadShort();
    }
}