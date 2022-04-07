using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LifePointsRegenBeginMessage : Message
{
    public const uint Id = 9626;

    public LifePointsRegenBeginMessage(byte regenRate)
    {
        RegenRate = regenRate;
    }

    public LifePointsRegenBeginMessage()
    {
    }

    public override uint MessageId => Id;

    public byte RegenRate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteByte(RegenRate);
    }

    public override void Deserialize(IDataReader reader)
    {
        RegenRate = reader.ReadByte();
    }
}