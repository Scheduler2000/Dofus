using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountXpRatioMessage : Message
{
    public const uint Id = 1527;

    public MountXpRatioMessage(sbyte ratio)
    {
        Ratio = ratio;
    }

    public MountXpRatioMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Ratio { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Ratio);
    }

    public override void Deserialize(IDataReader reader)
    {
        Ratio = reader.ReadSByte();
    }
}