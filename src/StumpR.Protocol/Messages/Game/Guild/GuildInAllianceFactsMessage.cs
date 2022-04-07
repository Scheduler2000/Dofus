using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInAllianceFactsMessage : GuildFactsMessage
{
    public new const uint Id = 6925;

    public GuildInAllianceFactsMessage(GuildFactSheetInformations infos,
        int creationDate,
        ushort nbTaxCollectors,
        IEnumerable<CharacterMinimalGuildPublicInformations> members,
        BasicNamedAllianceInformations allianceInfos)
    {
        Infos = infos;
        CreationDate = creationDate;
        NbTaxCollectors = nbTaxCollectors;
        Members = members;
        AllianceInfos = allianceInfos;
    }

    public GuildInAllianceFactsMessage()
    {
    }

    public override uint MessageId => Id;

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