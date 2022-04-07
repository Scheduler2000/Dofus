using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class QuestStepInfoRequestMessage : Message
{
    public const uint Id = 5562;

    public QuestStepInfoRequestMessage(ushort questId)
    {
        QuestId = questId;
    }

    public QuestStepInfoRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort QuestId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(QuestId);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestId = reader.ReadVarUShort();
    }
}