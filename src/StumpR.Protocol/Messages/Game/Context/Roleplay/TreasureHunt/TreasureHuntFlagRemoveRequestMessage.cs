using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TreasureHuntFlagRemoveRequestMessage : Message
{
    public const uint Id = 6823;

    public TreasureHuntFlagRemoveRequestMessage(sbyte questType, sbyte index)
    {
        QuestType = questType;
        Index = index;
    }

    public TreasureHuntFlagRemoveRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte QuestType { get; set; }

    public sbyte Index { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(QuestType);
        writer.WriteSByte(Index);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestType = reader.ReadSByte();
        Index = reader.ReadSByte();
    }
}