using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementListMessage : Message
{
    public const uint Id = 4607;

    public AchievementListMessage(IEnumerable<AchievementAchieved> finishedAchievements)
    {
        FinishedAchievements = finishedAchievements;
    }

    public AchievementListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AchievementAchieved> FinishedAchievements { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) FinishedAchievements.Count());

        foreach (AchievementAchieved objectToSend in FinishedAchievements)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort finishedAchievementsCount = reader.ReadUShort();
        var finishedAchievements_ = new AchievementAchieved[finishedAchievementsCount];

        for (var finishedAchievementsIndex = 0; finishedAchievementsIndex < finishedAchievementsCount; finishedAchievementsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<AchievementAchieved>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            finishedAchievements_[finishedAchievementsIndex] = objectToAdd;
        }
        FinishedAchievements = finishedAchievements_;
    }
}