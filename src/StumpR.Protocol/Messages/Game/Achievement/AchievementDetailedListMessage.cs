using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementDetailedListMessage : Message
{
    public const uint Id = 9855;

    public AchievementDetailedListMessage(IEnumerable<Achievement> startedAchievements, IEnumerable<Achievement> finishedAchievements)
    {
        StartedAchievements = startedAchievements;
        FinishedAchievements = finishedAchievements;
    }

    public AchievementDetailedListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<Achievement> StartedAchievements { get; set; }

    public IEnumerable<Achievement> FinishedAchievements { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) StartedAchievements.Count());
        foreach (Achievement objectToSend in StartedAchievements) objectToSend.Serialize(writer);
        writer.WriteShort((short) FinishedAchievements.Count());
        foreach (Achievement objectToSend in FinishedAchievements) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort startedAchievementsCount = reader.ReadUShort();
        var startedAchievements_ = new Achievement[startedAchievementsCount];

        for (var startedAchievementsIndex = 0; startedAchievementsIndex < startedAchievementsCount; startedAchievementsIndex++)
        {
            var objectToAdd = new Achievement();
            objectToAdd.Deserialize(reader);
            startedAchievements_[startedAchievementsIndex] = objectToAdd;
        }
        StartedAchievements = startedAchievements_;
        ushort finishedAchievementsCount = reader.ReadUShort();
        var finishedAchievements_ = new Achievement[finishedAchievementsCount];

        for (var finishedAchievementsIndex = 0; finishedAchievementsIndex < finishedAchievementsCount; finishedAchievementsIndex++)
        {
            var objectToAdd = new Achievement();
            objectToAdd.Deserialize(reader);
            finishedAchievements_[finishedAchievementsIndex] = objectToAdd;
        }
        FinishedAchievements = finishedAchievements_;
    }
}