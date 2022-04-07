using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountSetXpRatioRequestMessage : Message
{
    public const uint Id = 9275;

    public MountSetXpRatioRequestMessage(sbyte xpRatio)
    {
        XpRatio = xpRatio;
    }

    public MountSetXpRatioRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte XpRatio { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(XpRatio);
    }

    public override void Deserialize(IDataReader reader)
    {
        XpRatio = reader.ReadSByte();
    }
}