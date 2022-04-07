using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AlliancedGuildFactSheetInformations : GuildInformations
{
    public new const short Id = 1714;

    public AlliancedGuildFactSheetInformations(uint guildId,
        string guildName,
        byte guildLevel,
        GuildEmblem guildEmblem,
        BasicNamedAllianceInformations allianceInfos)
    {
        GuildId = guildId;
        GuildName = guildName;
        GuildLevel = guildLevel;
        GuildEmblem = guildEmblem;
        AllianceInfos = allianceInfos;
    }

    public AlliancedGuildFactSheetInformations()
    {
    }

    public override short TypeId => Id;

    public BasicNamedAllianceInformations AllianceInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        AllianceInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllianceInfos = new BasicNamedAllianceInformations();
        AllianceInfos.Deserialize(reader);
    }
}