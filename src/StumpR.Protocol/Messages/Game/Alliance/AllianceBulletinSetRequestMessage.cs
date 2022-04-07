using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceBulletinSetRequestMessage : SocialNoticeSetRequestMessage
{
    public new const uint Id = 645;

    public AllianceBulletinSetRequestMessage(string content, bool notifyMembers)
    {
        Content = content;
        NotifyMembers = notifyMembers;
    }

    public AllianceBulletinSetRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Content { get; set; }

    public bool NotifyMembers { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Content);
        writer.WriteBoolean(NotifyMembers);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Content = reader.ReadUTF();
        NotifyMembers = reader.ReadBoolean();
    }
}