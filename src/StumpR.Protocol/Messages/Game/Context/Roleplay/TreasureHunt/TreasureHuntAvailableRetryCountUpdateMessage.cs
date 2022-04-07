using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TreasureHuntAvailableRetryCountUpdateMessage : Message
{
    public const uint Id = 3416;

    public TreasureHuntAvailableRetryCountUpdateMessage(sbyte questType, int availableRetryCount)
    {
        QuestType = questType;
        AvailableRetryCount = availableRetryCount;
    }

    public TreasureHuntAvailableRetryCountUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte QuestType { get; set; }

    public int AvailableRetryCount { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(QuestType);
        writer.WriteInt(AvailableRetryCount);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestType = reader.ReadSByte();
        AvailableRetryCount = reader.ReadInt();
    }
}