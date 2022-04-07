using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
{
    public new const short Id = 6505;

    public TaxCollectorStaticExtendedInformations(ushort firstNameId,
        ushort lastNameId,
        GuildInformations guildIdentity,
        ulong callerId,
        AllianceInformations allianceIdentity)
    {
        FirstNameId = firstNameId;
        LastNameId = lastNameId;
        GuildIdentity = guildIdentity;
        CallerId = callerId;
        AllianceIdentity = allianceIdentity;
    }

    public TaxCollectorStaticExtendedInformations()
    {
    }

    public override short TypeId => Id;

    public AllianceInformations AllianceIdentity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        AllianceIdentity.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllianceIdentity = new AllianceInformations();
        AllianceIdentity.Deserialize(reader);
    }
}