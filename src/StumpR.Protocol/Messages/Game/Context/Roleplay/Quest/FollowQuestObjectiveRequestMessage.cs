using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FollowQuestObjectiveRequestMessage : Message
{
    public const uint Id = 8182;

    public FollowQuestObjectiveRequestMessage(ushort questId, short objectiveId)
    {
        QuestId = questId;
        ObjectiveId = objectiveId;
    }

    public FollowQuestObjectiveRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort QuestId { get; set; }

    public short ObjectiveId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(QuestId);
        writer.WriteShort(ObjectiveId);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestId = reader.ReadVarUShort();
        ObjectiveId = reader.ReadShort();
    }
}