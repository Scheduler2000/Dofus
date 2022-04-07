using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdentificationFailedBannedMessage : IdentificationFailedMessage
{
    public new const uint Id = 4124;

    public IdentificationFailedBannedMessage(sbyte reason, double banEndDate)
    {
        Reason = reason;
        BanEndDate = banEndDate;
    }

    public IdentificationFailedBannedMessage()
    {
    }

    public override uint MessageId => Id;

    public double BanEndDate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(BanEndDate);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        BanEndDate = reader.ReadDouble();
    }
}