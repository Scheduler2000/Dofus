using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TreasureHuntFlagRequestAnswerMessage : Message
{
    public const uint Id = 8784;

    public TreasureHuntFlagRequestAnswerMessage(sbyte questType, sbyte result, sbyte index)
    {
        QuestType = questType;
        Result = result;
        Index = index;
    }

    public TreasureHuntFlagRequestAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte QuestType { get; set; }

    public sbyte Result { get; set; }

    public sbyte Index { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(QuestType);
        writer.WriteSByte(Result);
        writer.WriteSByte(Index);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestType = reader.ReadSByte();
        Result = reader.ReadSByte();
        Index = reader.ReadSByte();
    }
}