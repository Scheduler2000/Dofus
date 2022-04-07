using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TreasureHuntDigRequestAnswerMessage : Message
{
    public const uint Id = 8845;

    public TreasureHuntDigRequestAnswerMessage(sbyte questType, sbyte result)
    {
        QuestType = questType;
        Result = result;
    }

    public TreasureHuntDigRequestAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte QuestType { get; set; }

    public sbyte Result { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(QuestType);
        writer.WriteSByte(Result);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestType = reader.ReadSByte();
        Result = reader.ReadSByte();
    }
}