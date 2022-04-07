using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class QuestObjectiveValidatedMessage : Message
{
    public const uint Id = 5565;

    public QuestObjectiveValidatedMessage(ushort questId, ushort objectiveId)
    {
        QuestId = questId;
        ObjectiveId = objectiveId;
    }

    public QuestObjectiveValidatedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort QuestId { get; set; }

    public ushort ObjectiveId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(QuestId);
        writer.WriteVarUShort(ObjectiveId);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestId = reader.ReadVarUShort();
        ObjectiveId = reader.ReadVarUShort();
    }
}