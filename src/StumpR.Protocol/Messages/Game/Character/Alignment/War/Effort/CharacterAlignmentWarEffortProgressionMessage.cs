using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterAlignmentWarEffortProgressionMessage : Message
{
    public const uint Id = 7324;

    public CharacterAlignmentWarEffortProgressionMessage(ulong alignmentWarEffortDailyLimit,
        ulong alignmentWarEffortDailyDonation,
        ulong alignmentWarEffortPersonalDonation)
    {
        AlignmentWarEffortDailyLimit = alignmentWarEffortDailyLimit;
        AlignmentWarEffortDailyDonation = alignmentWarEffortDailyDonation;
        AlignmentWarEffortPersonalDonation = alignmentWarEffortPersonalDonation;
    }

    public CharacterAlignmentWarEffortProgressionMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong AlignmentWarEffortDailyLimit { get; set; }

    public ulong AlignmentWarEffortDailyDonation { get; set; }

    public ulong AlignmentWarEffortPersonalDonation { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(AlignmentWarEffortDailyLimit);
        writer.WriteVarULong(AlignmentWarEffortDailyDonation);
        writer.WriteVarULong(AlignmentWarEffortPersonalDonation);
    }

    public override void Deserialize(IDataReader reader)
    {
        AlignmentWarEffortDailyLimit = reader.ReadVarULong();
        AlignmentWarEffortDailyDonation = reader.ReadVarULong();
        AlignmentWarEffortPersonalDonation = reader.ReadVarULong();
    }
}