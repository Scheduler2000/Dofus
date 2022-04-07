using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementFinishedMessage : Message
{
    public const uint Id = 8970;

    public AchievementFinishedMessage(AchievementAchievedRewardable achievement)
    {
        Achievement = achievement;
    }

    public AchievementFinishedMessage()
    {
    }

    public override uint MessageId => Id;

    public AchievementAchievedRewardable Achievement { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Achievement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Achievement = new AchievementAchievedRewardable();
        Achievement.Deserialize(reader);
    }
}