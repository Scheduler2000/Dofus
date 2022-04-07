using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class QuestValidatedMessage : Message
{
    public const uint Id = 1984;

    public QuestValidatedMessage(ushort questId)
    {
        QuestId = questId;
    }

    public QuestValidatedMessage()
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