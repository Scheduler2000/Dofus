using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceBulletinMessage : BulletinMessage
{
    public new const uint Id = 4021;

    public AllianceBulletinMessage(string content, int timestamp, ulong memberId, string memberName, int lastNotifiedTimestamp)
    {
        Content = content;
        Timestamp = timestamp;
        MemberId = memberId;
        MemberName = memberName;
        LastNotifiedTimestamp = lastNotifiedTimestamp;
    }

    public AllianceBulletinMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}