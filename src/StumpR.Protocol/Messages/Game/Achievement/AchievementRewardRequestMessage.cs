using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementRewardRequestMessage : Message
{
    public const uint Id = 3165;

    public AchievementRewardRequestMessage(short achievementId)
    {
        AchievementId = achievementId;
    }

    public AchievementRewardRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public short AchievementId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(AchievementId);
    }

    public override void Deserialize(IDataReader reader)
    {
        AchievementId = reader.ReadShort();
    }
}