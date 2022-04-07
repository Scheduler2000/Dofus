using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class QuestStartRequestMessage : Message
{
    public const uint Id = 6071;

    public QuestStartRequestMessage(ushort questId)
    {
        QuestId = questId;
    }

    public QuestStartRequestMessage()
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