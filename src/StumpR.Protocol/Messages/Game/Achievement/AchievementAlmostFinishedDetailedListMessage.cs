using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementAlmostFinishedDetailedListMessage : Message
{
    public const uint Id = 6475;

    public AchievementAlmostFinishedDetailedListMessage(IEnumerable<Achievement> almostFinishedAchievements)
    {
        AlmostFinishedAchievements = almostFinishedAchievements;
    }

    public AchievementAlmostFinishedDetailedListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<Achievement> AlmostFinishedAchievements { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) AlmostFinishedAchievements.Count());
        foreach (Achievement objectToSend in AlmostFinishedAchievements) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort almostFinishedAchievementsCount = reader.ReadUShort();
        var almostFinishedAchievements_ = new Achievement[almostFinishedAchievementsCount];

        for (var almostFinishedAchievementsIndex = 0;
             almostFinishedAchievementsIndex < almostFinishedAchievementsCount;
             almostFinishedAchievementsIndex++)
        {
            var objectToAdd = new Achievement();
            objectToAdd.Deserialize(reader);
            almostFinishedAchievements_[almostFinishedAchievementsIndex] = objectToAdd;
        }
        AlmostFinishedAchievements = almostFinishedAchievements_;
    }
}