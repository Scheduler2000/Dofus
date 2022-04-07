using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildInAllianceVersatileInformations : GuildVersatileInformations
{
    public new const short Id = 9740;

    public GuildInAllianceVersatileInformations(uint guildId, ulong leaderId, byte guildLevel, byte nbMembers, uint allianceId)
    {
        GuildId = guildId;
        LeaderId = leaderId;
        GuildLevel = guildLevel;
        NbMembers = nbMembers;
        AllianceId = allianceId;
    }

    public GuildInAllianceVersatileInformations()
    {
    }

    public override short TypeId => Id;

    public uint AllianceId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(AllianceId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllianceId = reader.ReadVarUInt();
    }
}