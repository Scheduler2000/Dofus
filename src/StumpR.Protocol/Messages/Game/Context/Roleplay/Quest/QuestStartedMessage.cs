using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class QuestStartedMessage : Message
{
    public const uint Id = 475;

    public QuestStartedMessage(ushort questId)
    {
        QuestId = questId;
    }

    public QuestStartedMessage()
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