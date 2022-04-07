using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceMotdMessage : SocialNoticeMessage
{
    public new const uint Id = 4427;

    public AllianceMotdMessage(string content, int timestamp, ulong memberId, string memberName)
    {
        Content = content;
        Timestamp = timestamp;
        MemberId = memberId;
        MemberName = memberName;
    }

    public AllianceMotdMessage()
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