using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementRewardSuccessMessage : Message
{
    public const uint Id = 2669;

    public AchievementRewardSuccessMessage(short achievementId)
    {
        AchievementId = achievementId;
    }

    public AchievementRewardSuccessMessage()
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