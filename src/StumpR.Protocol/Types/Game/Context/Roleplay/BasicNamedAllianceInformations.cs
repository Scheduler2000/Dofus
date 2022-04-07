using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class BasicNamedAllianceInformations : BasicAllianceInformations
{
    public new const short Id = 949;

    public BasicNamedAllianceInformations(uint allianceId, string allianceTag, string allianceName)
    {
        AllianceId = allianceId;
        AllianceTag = allianceTag;
        AllianceName = allianceName;
    }

    public BasicNamedAllianceInformations()
    {
    }

    public override short TypeId => Id;

    public string AllianceName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(AllianceName);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllianceName = reader.ReadUTF();
    }
}