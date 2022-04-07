using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AlignmentWarEffortDonatePreviewMessage : Message
{
    public const uint Id = 2736;

    public AlignmentWarEffortDonatePreviewMessage(double xp)
    {
        Xp = xp;
    }

    public AlignmentWarEffortDonatePreviewMessage()
    {
    }

    public override uint MessageId => Id;

    public double Xp { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(Xp);
    }

    public override void Deserialize(IDataReader reader)
    {
        Xp = reader.ReadDouble();
    }
}