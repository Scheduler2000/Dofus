using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildBulletinSetRequestMessage : SocialNoticeSetRequestMessage
{
    public new const uint Id = 7121;

    public GuildBulletinSetRequestMessage(string content, bool notifyMembers)
    {
        Content = content;
        NotifyMembers = notifyMembers;
    }

    public GuildBulletinSetRequestMessage()
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