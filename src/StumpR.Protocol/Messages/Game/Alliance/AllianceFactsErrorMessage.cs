using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceFactsErrorMessage : Message
{
    public const uint Id = 8954;

    public AllianceFactsErrorMessage(uint allianceId)
    {
        AllianceId = allianceId;
    }

    public AllianceFactsErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public uint AllianceId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(AllianceId);
    }

    public override void Deserialize(IDataReader reader)
    {
        AllianceId = reader.ReadVarUInt();
    }
}