using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AdminCommandMessage : Message
{
    public const uint Id = 4583;

    public AdminCommandMessage(string content)
    {
        Content = content;
    }

    public AdminCommandMessage()
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