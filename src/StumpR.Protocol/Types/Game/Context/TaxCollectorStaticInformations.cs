using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorStaticInformations
{
    public const short Id = 4022;

    public TaxCollectorStaticInformations(ushort firstNameId, ushort lastNameId, GuildInformations guildIdentity, ulong callerId)
    {
        FirstNameId = firstNameId;
        LastNameId = lastNameId;
        GuildIdentity = guildIdentity;
        CallerId = callerId;
    }

    public TaxCollectorStaticInformations()
    {
    }

    public virtual short TypeId => Id;

    public ushort FirstNameId { get; set; }

    public ushort LastNameId { get; set; }

    public GuildInformations GuildIdentity { get; set; }

    public ulong CallerId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FirstNameId);
        writer.WriteVarUShort(LastNameId);
        GuildIdentity.Serialize(writer);
        writer.WriteVarULong(CallerId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        FirstNameId = reader.ReadVarUShort();
        LastNameId = reader.ReadVarUShort();
        GuildIdentity = new GuildInformations();
        GuildIdentity.Deserialize(reader);
        CallerId = reader.ReadVarULong();
    }
}