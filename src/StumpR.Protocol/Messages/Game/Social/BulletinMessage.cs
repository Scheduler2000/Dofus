using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BulletinMessage : SocialNoticeMessage
{
    public new const uint Id = 9541;

    public BulletinMessage(string content, int timestamp, ulong memberId, string memberName, int lastNotifiedTimestamp)
    {
        Content = content;
        Timestamp = timestamp;
        MemberId = memberId;
        MemberName = memberName;
        LastNotifiedTimestamp = lastNotifiedTimestamp;
    }

    public BulletinMessage()
    {
    }

    public override uint MessageId => Id;

    public int LastNotifiedTimestamp { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(LastNotifiedTimestamp);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        LastNotifiedTimestamp = reader.ReadInt();
    }
}