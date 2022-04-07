using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeCrafterJobLevelupMessage : Message
{
    public const uint Id = 6591;

    public ExchangeCrafterJobLevelupMessage(byte crafterJobLevel)
    {
        CrafterJobLevel = crafterJobLevel;
    }

    public ExchangeCrafterJobLevelupMessage()
    {
    }

    public override uint MessageId => Id;

    public byte CrafterJobLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteByte(CrafterJobLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        CrafterJobLevel = reader.ReadByte();
    }
}