using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FollowedQuestsMessage : Message
{
    public const uint Id = 414;

    public FollowedQuestsMessage(IEnumerable<QuestActiveDetailedInformations> quests)
    {
        Quests = quests;
    }

    public FollowedQuestsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<QuestActiveDetailedInformations> Quests { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Quests.Count());
        foreach (QuestActiveDetailedInformations objectToSend in Quests) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort questsCount = reader.ReadUShort();
        var quests_ = new QuestActiveDetailedInformations[questsCount];

        for (var questsIndex = 0; questsIndex < questsCount; questsIndex++)
        {
            var objectToAdd = new QuestActiveDetailedInformations();
            objectToAdd.Deserialize(reader);
            quests_[questsIndex] = objectToAdd;
        }
        Quests = quests_;
    }
}