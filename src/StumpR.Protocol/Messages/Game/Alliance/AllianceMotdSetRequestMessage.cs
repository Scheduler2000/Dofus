using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage
{
    public new const uint Id = 3707;

    public AllianceMotdSetRequestMessage(string content)
    {
        Content = content;
    }

    public AllianceMotdSetRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Content { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Content);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Content = reader.ReadUTF();
    }
}