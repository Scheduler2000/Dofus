using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceModificationNameAndTagValidMessage : Message
{
    public const uint Id = 8950;

    public AllianceModificationNameAndTagValidMessage(string allianceName, string allianceTag)
    {
        AllianceName = allianceName;
        AllianceTag = allianceTag;
    }

    public AllianceModificationNameAndTagValidMessage()
    {
    }

    public override uint MessageId => Id;

    public string AllianceName { get; set; }

    public string AllianceTag { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(AllianceName);
        writer.WriteUTF(AllianceTag);
    }

    public override void Deserialize(IDataReader reader)
    {
        AllianceName = reader.ReadUTF();
        AllianceTag = reader.ReadUTF();
    }
}