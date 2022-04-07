using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatAbstractClientMessage : Message
{
    public const uint Id = 1037;

    public ChatAbstractClientMessage(string content)
    {
        Content = content;
    }

    public ChatAbstractClientMessage()
    {
    }

    public override uint MessageId => Id;

    public string Content { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Content);
    }

    public override void Deserialize(IDataReader reader)
    {
        Content = reader.ReadUTF();
    }
}