using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendGuildWarnOnAchievementCompleteStateMessage : Message
{
    public const uint Id = 8244;

    public FriendGuildWarnOnAchievementCompleteStateMessage(bool enable)
    {
        Enable = enable;
    }

    public FriendGuildWarnOnAchievementCompleteStateMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Enable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(IDataReader reader)
    {
        Enable = reader.ReadBoolean();
    }
}