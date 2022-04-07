using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AlignmentWarEffortDonateRequestMessage : Message
{
    public const uint Id = 5249;

    public AlignmentWarEffortDonateRequestMessage(ulong donation)
    {
        Donation = donation;
    }

    public AlignmentWarEffortDonateRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Donation { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Donation);
    }

    public override void Deserialize(IDataReader reader)
    {
        Donation = reader.ReadVarULong();
    }
}