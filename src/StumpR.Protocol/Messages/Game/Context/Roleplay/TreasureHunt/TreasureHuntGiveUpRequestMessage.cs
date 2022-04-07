using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TreasureHuntGiveUpRequestMessage : Message
{
    public const uint Id = 2962;

    public TreasureHuntGiveUpRequestMessage(sbyte questType)
    {
        QuestType = questType;
    }

    public TreasureHuntGiveUpRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte QuestType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(QuestType);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestType = reader.ReadSByte();
    }
}