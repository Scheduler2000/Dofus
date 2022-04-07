using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendGuildSetWarnOnAchievementCompleteMessage : Message
{
    public const uint Id = 2644;

    public FriendGuildSetWarnOnAchievementCompleteMessage(bool enable)
    {
        Enable = enable;
    }

    public FriendGuildSetWarnOnAchievementCompleteMessage()
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