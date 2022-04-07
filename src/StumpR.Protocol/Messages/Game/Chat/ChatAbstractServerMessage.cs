using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatAbstractServerMessage : Message
{
    public const uint Id = 3393;

    public ChatAbstractServerMessage(sbyte channel, string content, int timestamp, string fingerprint)
    {
        Channel = channel;
        Content = content;
        Timestamp = timestamp;
        Fingerprint = fingerprint;
    }

    public ChatAbstractServerMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Channel { get; set; }

    public string Content { get; set; }

    public int Timestamp { get; set; }

    public string Fingerprint { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Channel);
        writer.WriteUTF(Content);
        writer.WriteInt(Timestamp);
        writer.WriteUTF(Fingerprint);
    }

    public override void Deserialize(IDataReader reader)
    {
        Channel = reader.ReadSByte();
        Content = reader.ReadUTF();
        Timestamp = reader.ReadInt();
        Fingerprint = reader.ReadUTF();
    }
}