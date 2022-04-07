using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AllianceInformations : BasicNamedAllianceInformations
{
    public new const short Id = 5338;

    public AllianceInformations(uint allianceId, string allianceTag, string allianceName, GuildEmblem allianceEmblem)
    {
        AllianceId = allianceId;
        AllianceTag = allianceTag;
        AllianceName = allianceName;
        AllianceEmblem = allianceEmblem;
    }

    public AllianceInformations()
    {
    }

    public override short TypeId => Id;

    public GuildEmblem AllianceEmblem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        AllianceEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllianceEmblem = new GuildEmblem();
        AllianceEmblem.Deserialize(reader);
    }
}