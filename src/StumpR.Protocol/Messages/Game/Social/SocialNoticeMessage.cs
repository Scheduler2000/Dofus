using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SocialNoticeMessage : Message
{
    public const uint Id = 8560;

    public SocialNoticeMessage(string content, int timestamp, ulong memberId, string memberName)
    {
        Content = content;
        Timestamp = timestamp;
        MemberId = memberId;
        MemberName = memberName;
    }

    public SocialNoticeMessage()
    {
    }

    public override uint MessageId => Id;

    public string Content { get; set; }

    public int Timestamp { get; set; }

    public ulong MemberId { get; set; }

    public string MemberName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Content);
        writer.WriteInt(Timestamp);
        writer.WriteVarULong(MemberId);
        writer.WriteUTF(MemberName);
    }

    public override void Deserialize(IDataReader reader)
    {
        Content = reader.ReadUTF();
        Timestamp = reader.ReadInt();
        MemberId = reader.ReadVarULong();
        MemberName = reader.ReadUTF();
    }
}