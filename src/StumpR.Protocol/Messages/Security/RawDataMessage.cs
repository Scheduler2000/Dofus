using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class RawDataMessage : Message
{
    public const uint Id = 4602;

    public RawDataMessage()
    {
    }

    public RawDataMessage(byte[] content)
    {
        Content = content;
    }

    public override uint MessageId => Id;

    public byte[] Content { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        int contentLength = Content.Length;
        writer.WriteVarInt(contentLength);
        for (var i = 0; i < contentLength; i++) writer.WriteByte(Content[i]);
    }

    public override void Deserialize(IDataReader reader)
    {
        int contentLength = reader.ReadVarInt();
        reader.ReadBytes(contentLength);
    }
}